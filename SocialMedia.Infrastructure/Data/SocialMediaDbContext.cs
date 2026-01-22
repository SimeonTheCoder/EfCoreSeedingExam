using Microsoft.EntityFrameworkCore;
using SocialMedia.Infrastructure.Data.Configurations;
using SocialMedia.Infrastructure.Data.Models;

namespace SocialMedia.Infrastructure.Data
{
    public class SocialMediaDbContext : DbContext
    {
        private const string ConnectionString = "Server=localhost, 1433;Database=SocialMedia;User Id=sa;Password=pass123*;Trust Server Certificate=True;Encrypt=False";

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(ConnectionString);
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Post> Posts {get; set;}
        public DbSet<Message> Messages {get; set;}
    }
}