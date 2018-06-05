using AutoMapper;
using Brownbag.Data.Models;
using Brownbag.Web.Extensions;
using Brownbag.Web.Models;
using Brownbag.Web.Models.PrimeNG.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Brownbag.Web.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;

        public PostController(IMapper mapper, ApplicationDataContext appDbContext)
        {
            _mapper = mapper;
            _context = appDbContext;
        }

        // GET api/Admin/[controller]?{currentPage}&{rows}&{searchQuery}
        [HttpGet]
        public GridViewModel<PostViewModel> Read(int currentPage, int rows, string searchQuery)
        {
            GridViewModel<PostViewModel> vm = new GridViewModel<PostViewModel>();

            try
            {
                int maxRows = rows == 0 ? 10 : rows;
                currentPage = currentPage == 0 ? 1 : currentPage;

                IQueryable<Post> query = _context.Posts.Include(x=>x.Blog);

                if (searchQuery != null)
                {
                    query = query.Where(
                        e => e.Content.CaseInsensitiveContains(searchQuery) ||
                        e.Title.CaseInsensitiveContains(searchQuery) ||
                        e.Blog.Url.CaseInsensitiveContains(searchQuery)
                        );
                    // Returns the search query to help maintain state
                    vm.SearchQuery = searchQuery;
                }
                double pageCount = (double)((decimal)query.Count() / Convert.ToDecimal(maxRows));
                vm.PageCount = (int)Math.Ceiling(pageCount);

                query = query
                        .OrderBy(item => item.Id).Skip((currentPage - 1) * maxRows)
                        .Take(maxRows);

                var mapped = _mapper.Map<PostViewModel[]>(query);
                vm.Data = mapped;

                vm.Page = currentPage;
                vm.Rows = maxRows;

                return vm;
            }
            catch (Exception ex)
            {
                vm.Errors = ex.ToString();
                return vm;
            }

        }

        // GET api/Admin/[controller]/{id}
        [HttpGet("{id:int}")]
        public Post Edit([FromRoute]int id)
        {
            /*
            We are NOT using automapper here even because we can just return the entity because
            it has no has virtual or irrelevant properties which should not be sent for no reason.
            If you look at OccupationalSpecialtyController it does the opposite
             */
            return _context.Posts.Include(x => x.Blog).Where(y => y.Id.Equals(id)).FirstOrDefault();
        }

        // POST api/Admin/[controller]
        [HttpPost()]
        public ActionResult Create([FromBody]Post entity)
        {
            /*
            To follow Microsoft API Guidance Post method is left here. 
            However since our add and update methods are basically
            the same, to save a step they share a save and update 
            method. This method simply passes the data to the update
            method.
            Source: http://aka.ms/RestApiGuidance
             */
            return Update(entity);
        }

        // PUT api/Admin/[controller]
        [HttpPut()]
        public ActionResult Update([FromBody]Brownbag.Data.Models.Post entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                /*
                EF Core 2.0+ Assumes if Id = 0 then you want to add.
                So we can effectively use the same method for create
                and update since leaving out the Id or explicitly 
                setting it to 0 will let EF know that its an add not
                update
                 */
                _context.Posts.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Generic Error", "Something went wrong, please contact administrator" + ex);
                return BadRequest(ModelState);
            }
            return Json(new[] { entity });
        }



    }
}