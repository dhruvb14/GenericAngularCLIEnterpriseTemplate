using System;
using Reinforced.Typings.Attributes;

namespace Models
{
    [TsInterface (AutoI = false)]    
    public class GuidLookupViewModel
    {
        public Guid ID { get; set; }
        public string Value { get; set; }
    }
}