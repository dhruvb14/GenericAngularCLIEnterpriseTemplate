using Reinforced.Typings.Attributes;

namespace Models
{
    [TsInterface (AutoI = false)]    
    public class LookupViewModel
    {
        public int ID { get; set; }
        public string Value { get; set; }
    }
}