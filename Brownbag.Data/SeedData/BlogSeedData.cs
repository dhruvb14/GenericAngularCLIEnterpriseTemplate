using System;
using Brownbag.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bom.Data {
    public static class BlogSeedData {
        public static void Initialize(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Blog>().HasData(
                new Blog { Id = 1, Url = "www.microsoft.com", Rating = 10, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now },
                new Blog { Id = 2, Url = "www.microsoft.net", Rating = 9, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now  },
                new Blog { Id = 3, Url = "www.microsoft.org", Rating = 8, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now  },
                new Blog { Id = 4, Url = "www.google.com", Rating = 7, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now  },
                new Blog { Id = 5, Url = "www.google.org", Rating = 6, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now  },
                new Blog { Id = 6, Url = "www.google.net", Rating = 5, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now  }
            );
        }
    }
}