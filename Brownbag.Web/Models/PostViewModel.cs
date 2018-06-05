using Brownbag.Data.Models;
using Reinforced.Typings.Attributes;

namespace Brownbag.Web.Models {
    [TsInterface (AutoI = false)]
    public class PostViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}