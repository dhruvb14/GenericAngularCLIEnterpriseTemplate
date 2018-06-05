using System;
using System.ComponentModel.DataAnnotations.Schema;
using Brownbag.Data.Interfaces;

namespace Brownbag.Data.Models {
    public class Post : IAuditable {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        [ForeignKey ("CreatedByUser")]
        public Guid CreatedBy { get; set; }
        public User CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey ("UpdatedByUser")]
        public Guid? UpdatedBy { get; set; }
        public User UpdatedByUser { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
    }
}