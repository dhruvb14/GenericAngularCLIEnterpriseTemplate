using Reinforced.Typings.Attributes;

namespace Models
{
    [TsInterface (AutoI = false)]
    public class UsersViewModel
    {
        public string UserFullName { get; set; }
    }
}