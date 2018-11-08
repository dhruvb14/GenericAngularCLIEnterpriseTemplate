using System;
using Brownbag.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bom.Data {
    public static class PostSeedData {
        public static void Initialize(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Post 1", Content = "Test Content", BlogId = 1, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now },
                new Post { Id = 2, Title = "Post 2", Content = "Test Content", BlogId = 1, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now },
                new Post { Id = 3, Title = "Post 3", Content = "Test Content", BlogId = 1, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now },
                new Post { Id = 4, Title = "Post 4", Content = "Test Content", BlogId = 2, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now },
                new Post { Id = 5, Title = "Post 5", Content = "Test Content", BlogId = 2, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now },
                new Post { Id = 6, Title = "Post 6", Content = "Test Content", BlogId = 3, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now },
                new Post { Id = 7, Title = "Post 7", Content = "Test Content", BlogId = 4, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now },
                new Post { Id = 8, Title = "Post 8", Content = "Test Content", BlogId = 5, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now },
                new Post { Id = 9, Title = "Post 9", Content = "Test Content", BlogId = 6, CreatedBy = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"), CreatedDate = DateTime.Now }
            );
        }
    }
}