using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Brownbag.Data.Models;
using Brownbag.Web.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.PrimeNG.Grid;

namespace Bom.Web.Controllers.Lookups {
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsSuperAdmin")]
    [Route("api/[controller]")]
    public class UsersController : Controller {
        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UsersController(IMapper mapper, ApplicationDataContext appDbContext, UserManager<User> userManager) {
            _userManager = userManager;
            _mapper = mapper;
            _context = appDbContext;
        }

        // GET api/Admin/[controller]?{currentPage}&{rows}&{searchQuery}
        [HttpGet]
        public async Task<GridViewModel<UsersViewModel>> ReadAsync(int currentPage, int rows, string searchQuery) {
            GridViewModel<UsersViewModel> vm = new GridViewModel<UsersViewModel>();

            try {
                int maxRows = rows == 0 ? 10 : rows;
                currentPage = currentPage == 0 ? 1 : currentPage;

                IQueryable<Brownbag.Data.Models.User> query = _context.Users;

                if (searchQuery != null) {
                    query = query.Where(
                        e => e.UserFullName.CaseInsensitiveContains(searchQuery)
                    );
                    // Returns the search query to help maintain state
                    vm.SearchQuery = searchQuery;
                }
                double pageCount = (double) ((decimal) query.Count() / Convert.ToDecimal(maxRows));
                vm.PageCount = (int) Math.Ceiling(pageCount);

                query = query
                    .OrderBy(item => item.UserName).Skip((currentPage - 1) * maxRows)
                    .Take(maxRows);

                var mapped = _mapper.Map<UsersViewModel[]>(query);
                vm.Data = mapped;

                foreach (UsersViewModel user in vm.Data) {
                    var currentUser = await _userManager.FindByIdAsync(user.Id);
                    foreach (var claim in await _userManager.GetRolesAsync(currentUser)) {
                        var item = new StringOptionsLookupViewModel();
                        item.value = claim;
                        item.label = claim;
                        item.disabled = false;
                        user.Roles.Add(item);
                    }
                }
                vm.Page = currentPage;
                vm.Rows = maxRows;

                return vm;
            } catch (Exception ex) {
                vm.Errors = ex.ToString();
                return vm;
            }

        }

        // GET api/Admin/[controller]/{id}
        [HttpGet("{id}")]
        public async Task<UsersViewModel> EditAsync([FromRoute] Guid id) {
            /*
            We are NOT using automapper here even because we can just return the entity because
            it has no has virtual or irrelevant properties which should not be sent for no reason.
            If you look at OccupationalSpecialtyController it does the opposite
             */
            var user = _mapper.Map<UsersViewModel>(_context.Users.Where(y => y.Id.Equals(id)).FirstOrDefault());
            var currentUser = await _userManager.FindByIdAsync(id.ToString());
            foreach (var role in await _userManager.GetRolesAsync(currentUser)) {
                var item = new StringOptionsLookupViewModel();
                item.value = role;
                item.label = role;
                item.disabled = false;
                user.Roles.Add(item);
            }
            return user;
        }

        // POST api/Admin/[controller]
        [HttpPost()]
        public async Task<ActionResult> CreateAsync([FromBody] UsersViewModel entity) {
            /*
            To follow Microsoft API Guidance Post method is left here. 
            However since our add and update methods are basically
            the same, to save a step they share a save and update 
            method. This method simply passes the data to the update
            method.
            Source: http://aka.ms/RestApiGuidance
             */
            try {
                if (!ModelState.IsValid) {
                    return BadRequest(ModelState);
                }
                /*
                EF Core 2.0+ Assumes if Id = 0 then you want to add.
                So we can effectively use the same method for create
                and update since leaving out the Id or explicitly 
                setting it to 0 will let EF know that its an add not
                update
                 */
                //  var currentUser = _context.Users.Find(entity.Id)
                // var user = _mapper.Map<AppUser>(entity);
                var userIdentity = new Brownbag.Data.Models.User();
                userIdentity.UserFullName = entity.UserFullName;
                userIdentity.UserName = entity.UserName;
                var result = await _userManager.CreateAsync(userIdentity);

                if (!result.Succeeded) {
                    ModelState.AddModelError("Generic Error", "Something went wrong, please contact administrator" + result.Errors);
                    return BadRequest(ModelState);
                }

                var userToVerify = await _userManager.FindByNameAsync(entity.UserName);

               if (result.Succeeded) { 
                    foreach (var role in entity.Roles) {
                        await _userManager.AddToRoleAsync(userIdentity, role.value);
                    }
                }

                // _appDbContext.SaveChanges();

                // _context.Users.Update(user);
                _context.SaveChanges();
            } catch (Exception ex) {
                ModelState.AddModelError("Generic Error", "Something went wrong, please contact administrator" + ex);
                return BadRequest(ModelState);
            }
            return Json(new [] { entity });
        }

        // // PUT api/Admin/[controller]
        // [HttpPut()]
        // public async Task<ActionResult> UpdateAsync([FromBody] UsersClaimsViewModel entity) {
        //     try {
        //         if (!ModelState.IsValid) {
        //             return BadRequest(ModelState);
        //         }
        //         /*
        //         EF Core 2.0+ Assumes if Id = 0 then you want to add.
        //         So we can effectively use the same method for create
        //         and update since leaving out the Id or explicitly 
        //         setting it to 0 will let EF know that its an add not
        //         update
        //          */
        //         //  var currentUser = _context.Users.Find(entity.Id)
        //         // var user = _mapper.Map<AppUser>(entity);
        //         var currentUser = await _userManager.FindByIdAsync(entity.Id);
        //         currentUser.FirstName = entity.FirstName;
        //         currentUser.LastName = entity.LastName;
        //         currentUser.UserName = entity.UserName;
        //         foreach (var claim in await _userManager.GetClaimsAsync(currentUser)) {
        //             if (claim.Type == "Permissions") {
        //                 await _userManager.RemoveClaimAsync(currentUser, claim);
        //             }
        //         }
        //         foreach (var claim in entity.Claims) {
        //             await _userManager.AddClaimAsync(currentUser, new Claim(BomClaims.Permissions, claim.value));
        //         }

        //         // _context.Users.Update(user);
        //         _context.SaveChanges();
        //     } catch (Exception ex) {
        //         ModelState.AddModelError("Generic Error", "Something went wrong, please contact administrator" + ex);
        //         return BadRequest(ModelState);
        //     }
        //     return Json(new [] { entity });
        // }
    }
}