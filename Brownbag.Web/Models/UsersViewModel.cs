using Reinforced.Typings.Attributes;

namespace Brownbag.Web.Models
{
    [TsInterface (AutoI = false)]
    public class UsersViewModel
    {
        public string UserFullName { get; set; }
    }
}