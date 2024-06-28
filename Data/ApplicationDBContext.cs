using BlogApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<FilesModel> file { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Comment> comments { get; set; }

        public DbSet<LikesModel> likes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<LikesModel>(l => l.HasKey(l => new {l.UserId,l.PostId}));

            modelBuilder.Entity<LikesModel>()
                .HasOne(l => l.posts)
                .WithMany(l => l.likes)
                .HasForeignKey(l => l.PostId);

            modelBuilder.Entity<LikesModel>()
                .HasOne(l => l.users)
                .WithMany(l => l.likes)
                .HasForeignKey(l => l.UserId);

            



            
        }

    }
}
