using System;
using System.Collections.Generic;
using Brownbag.Data.Interfaces;

namespace Brownbag.Data.Models
{
    public class Blog : IAuditable
    {
        public Blog()
        {
        }
        public int Id { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public ICollection<Post> Posts { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}