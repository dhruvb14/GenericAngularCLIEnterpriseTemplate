using System.Collections.Generic;
using Reinforced.Typings.Attributes;

namespace Models
{
    [TsInterface (AutoI = false)]
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public IList<StringOptionsLookupViewModel> Roles { get; set; } = new List<StringOptionsLookupViewModel>();

        public bool Active { get; set; }
    }
}