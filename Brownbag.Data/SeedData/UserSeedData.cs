using System;
using Brownbag.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bom.Data {
    public static class UserSeedData {
        public static void Initialize(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasData(
                new User {
                    Id = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"),
                        ConcurrencyStamp = "a179afd9-9b34-4713-8295-a1505340cec7",
                        AccessFailedCount = 0,
                        EmailConfirmed = false,
                        UserFullName = "Dhruv Bhavsar",
                        LockoutEnabled = true,
                        NormalizedUserName = "MICROSOFT\\DHRUV",
                        PasswordHash = "",
                        PhoneNumberConfirmed = false,
                        SecurityStamp = "d6775817-bb1a-4d77-8ed7-1d430c91d7f1",
                        TwoFactorEnabled = false,
                        UserName = "Microsoft\\dhruv"
                }
            );
            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid> {
                    Id = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f78"),
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "d6775817-bb1a-4d77-8ed7-1d430c91d7f1"
                },
                new IdentityRole<Guid> {
                    Id = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f79"),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    ConcurrencyStamp = "d6775817-bb1a-4d77-8ed7-1d430c91d7f1"
                },
                new IdentityRole<Guid> {
                    Id = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f71"),
                    Name = "Developer",
                    NormalizedName = "DEVELOPER",
                    ConcurrencyStamp = "d6775817-bb1a-4d77-8ed7-1d430c91d7f1"
                }
            );
             modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid> {
                    UserId = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"),
                    RoleId = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f79")
                },
                new IdentityUserRole<Guid> {
                    UserId = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"),
                    RoleId = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f78")
                },
                 new IdentityUserRole<Guid> {
                    UserId = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f72"),
                    RoleId = Guid.Parse("2c91c203-6dc2-4428-87fb-cc60a5300f71")
                }
            );
        }
    }
}