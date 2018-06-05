using System;
using Reinforced.Typings.Attributes;

namespace Brownbag.Web.Models
{
    [TsInterface (AutoI = false)]    
    public class GuidLookupViewModel
    {
        public Guid ID { get; set; }
        public string Value { get; set; }
    }
}