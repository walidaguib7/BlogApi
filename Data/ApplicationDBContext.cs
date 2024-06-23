using BlogApi.Models;
using Microsoft.AspNetCore.Identity;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.post)
                .WithMany(c => c.comments)
                .HasForeignKey(c => c.PostId);
        }

    }
}
