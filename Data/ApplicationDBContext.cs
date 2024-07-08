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

        public DbSet<CommentLikes> commentLikes { get; set; }

        public DbSet<UserFollower> followers { get; set; }

        public DbSet<Replies> replies { get; set; }



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


            modelBuilder.Entity<CommentLikes>(c => c.HasKey(c => new { c.UserId, c.CommentId }));


            modelBuilder.Entity<CommentLikes>()
                .HasOne(c => c.users)
                .WithMany(c => c.commentLikes)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<CommentLikes>()
                .HasOne(c => c.comments)
                .WithMany(c => c.commentLikes)
                .HasForeignKey(c => c.CommentId);


            modelBuilder.Entity<UserFollower>(u => u.HasKey(u => new { u.UserId, u.FollowerId }));

            modelBuilder.Entity<User>()
                    .HasMany(u => u.followers)
                    .WithOne(uf => uf.User)
                    .HasForeignKey(uf => uf.UserId);










        }

    }
}
