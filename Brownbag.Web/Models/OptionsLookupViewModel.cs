using Reinforced.Typings.Attributes;

namespace Models
{
    [TsInterface (AutoI = false)]    
    public class OptionsLookupViewModel
    {
        public string label { get; set; }
        public int value { get; set; }
        public bool disabled { get; set; }
    }
    [TsInterface (AutoI = false)]    
    public class StringOptionsLookupViewModel
    {
        public string label { get; set; }
        public string value { get; set; }
        public bool disabled { get; set; }
    }
    
}