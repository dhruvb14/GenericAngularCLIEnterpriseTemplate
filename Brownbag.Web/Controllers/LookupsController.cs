using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Brownbag.Data.Models;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace Brownbag.Web.Controllers {
    
    [Route ("api/[controller]")]
    public class LookupsController : Controller {
        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;
        public LookupsController (IMapper mapper, ApplicationDataContext appDbContext) {
            _mapper = mapper;
            _context = appDbContext;
        }

        [HttpGet ("[action]")]
        public IEnumerable<LookupViewModel> Blogs () {
            return _context.Blogs.Select (blog => new LookupViewModel {
                ID = blog.Id,
                    Value = blog.Url
            });
        }

    }
}