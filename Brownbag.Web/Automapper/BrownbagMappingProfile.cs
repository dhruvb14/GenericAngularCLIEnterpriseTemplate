using Brownbag.Data.Models;
using Models;

namespace Brownbag.Web.Automapper
{
    public class BrownbagMappingProfile : AutoMapper.Profile
    {
        public BrownbagMappingProfile()
        {
            CreateMap<Blog, BlogViewModel>()
           .ReverseMap();
            CreateMap<Blog, BlogFKViewModel>()
           .ReverseMap();           
            CreateMap<Post, PostViewModel>()
           .ReverseMap();
           CreateMap<Post, BlogPostsViewModel>();
        }
    }
}