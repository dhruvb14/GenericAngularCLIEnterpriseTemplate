using Reinforced.Typings.Attributes;

namespace Brownbag.Web.Models
{
    [TsInterface (AutoI = false)]    
    public class LookupViewModel
    {
        public int ID { get; set; }
        public string Value { get; set; }
    }
}