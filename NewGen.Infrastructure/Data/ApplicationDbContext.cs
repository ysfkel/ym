
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewGen.DomainModel.Models;

namespace NewGen.Infrastrcuture.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
         :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PostTag>()
            .HasKey(t=>new {t.PostId,t.TagId});

            builder.Entity<PostTag>()
            .HasOne(pt=>pt.Post)
            .WithMany(p=>p.PostTags)
            .HasForeignKey(pt=>pt.PostId);

            builder.Entity<PostTag>()
            .HasOne(pt=>pt.Tag)
            .WithMany(t=>t.PostTags)
            .HasForeignKey(pt=>pt.TagId);



        }

        public DbSet<Post>Posts{get;set;}
        public DbSet<Comment>Comments{get;set;}
        public DbSet<Tag>Tags{get;set;}
        public DbSet<Video>Video{get;set;}
    }
}
