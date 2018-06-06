using System;

namespace Brownbag.Web.Metadata
{
    public class RemoteForeignKeyAttribute: Attribute
    {
            public string Repository { get; set; }
            public string Endpoint { get; set; }
            public string IDField { get; set; }
            public string StringLiteral { get; set; }
            public string ValueField { get; set; }
            public string Delimiter { get; set; }
            public string Lookup { get; set; }
    }
}