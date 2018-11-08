using System;
using Brownbag.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Brownbag.Web.Middleware;
using System.Collections.Generic;
using Reinforced.Typings.Attributes;

namespace Models
{
    [TsInterface(AutoI = false)]
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }

    }
}