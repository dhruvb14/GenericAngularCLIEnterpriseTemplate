using Brownbag.Data.Models;
using Brownbag.Web.Models;

namespace Brownbag.Web.Automapper
{
    public class BrownbagMappingProfile : AutoMapper.Profile
    {
        public BrownbagMappingProfile()
        {
            CreateMap<Blog, BlogViewModel>()
           .ReverseMap();
            CreateMap<Post, PostViewModel>()
           .ReverseMap();
           CreateMap<Post, BlogPostsViewModel>();
        }
    }
}