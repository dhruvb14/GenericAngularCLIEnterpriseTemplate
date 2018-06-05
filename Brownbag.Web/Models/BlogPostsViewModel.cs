using System;
using Reinforced.Typings.Attributes;

namespace Brownbag.Web.Models {
    [TsInterface (AutoI = false)]
    public class BlogPostsViewModel : PostViewModel {
        public UsersViewModel CreatedByUser { get; set; }
        public UsersViewModel UpdatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}