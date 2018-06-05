using System;
using Brownbag.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Brownbag.Data.Models
{
    public partial class ApplicationDataContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        private IHttpContextAccessor _context { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options, IHttpContextAccessor contextAccessor) : base(options)
        {
            _context = contextAccessor;
        }
        public override int SaveChanges()
        {
            // https://stackoverflow.com/questions/36401026/how-to-get-user-information-in-dbcontext-using-net-core
            // https://stackoverflow.com/questions/35765204/how-can-i-get-user-and-claim-information-using-action-filters/35826744
            foreach (var auditableEntity in ChangeTracker.Entries<IAuditable>())
            {
                if (auditableEntity.State == EntityState.Added ||
                    auditableEntity.State == EntityState.Modified)
                {

                    auditableEntity.Entity.UpdatedDate = DateTime.Now;
                    auditableEntity.Entity.UpdatedBy = new Guid(_context.HttpContext.User.FindFirst("userId").Value);

                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.CreatedDate = DateTime.Now;
                        auditableEntity.Entity.CreatedBy = new Guid(_context.HttpContext.User.FindFirst("userId").Value);
                    }
                    else
                    {
                        auditableEntity.Property(p => p.CreatedDate).IsModified = false;
                        auditableEntity.Property(p => p.CreatedBy).IsModified = false;
                    }
                }
            }
            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>(entity => {
                entity.HasKey(r => new { r.Id });
                entity.ToTable("AspNetUsers");
            });

            modelBuilder.Entity<IdentityRole<Guid>>(entity => {
                entity.HasKey(r => new { r.Id });
                entity.ToTable("AspNetRoles");
            });

            modelBuilder.Entity<IdentityUserClaim<Guid>>(entity => {
                entity.HasKey(r => new { r.Id });
                entity.ToTable("AspNetUserClaims");
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>(entity => {
                entity.HasKey(r => new { r.UserId, r.RoleId });
                entity.ToTable("AspNetUserRoles");
            });

            modelBuilder.Entity<IdentityUserLogin<Guid>>(entity => {
                entity.HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
                entity.ToTable("AspNetUserLogins");
            });

            modelBuilder.Entity<IdentityUserToken<Guid>>(entity => {
                entity.HasKey(r => r.UserId);
                entity.ToTable("AspNetUserTokens");
            });
        }
    }
}