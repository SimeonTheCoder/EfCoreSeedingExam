using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Data.DTOs;
using SocialMedia.Infrastructure.Data.Models;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            List<Post> posts = new();
            List<PostDTO>? dtos = GetPostDTOs() ?? new();

            foreach (PostDTO dto in dtos)
            {
                Post curr = Parse(dto);
                posts.Add(curr);
            }

            builder.HasData(posts);
        }

        private List<PostDTO>? GetPostDTOs()
        {
            string text = File.ReadAllText("../SocialMedia.Infrastructure/Data/JSON/posts.json");
            
            List<PostDTO>? dtos = JsonSerializer.Deserialize<List<PostDTO>>(text);
            
            return dtos;
        }

        private Post Parse(PostDTO dto)
        {
            Post post = new();

            post.Id = dto.Id;
            post.Content = dto.Content;
            post.UserId = dto.UserId;
            post.CreatedAt = dto.CreatedAt;
            post.Image = dto.Image ?? "";

            return post;
        }
    }
}