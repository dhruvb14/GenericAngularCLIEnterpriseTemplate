using System;
using Brownbag.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Brownbag.Web.Middleware;
using System.Collections.Generic;
using Reinforced.Typings.Attributes;
using Brownbag.Web.Metadata;

namespace Models
{
    [TsInterface(AutoI = false)]
    public class BlogFKViewModel: BlogViewModel
    {
        public int WeatherID { get; set; } = 44418;
                
        [RemoteForeignKey(Repository = "Weather", Endpoint = "location", IDField = "WeatherID", ValueField = "title", Delimiter = " - ", StringLiteral = "true")]
        public string WeatherCityName { get; set; }
    }
}