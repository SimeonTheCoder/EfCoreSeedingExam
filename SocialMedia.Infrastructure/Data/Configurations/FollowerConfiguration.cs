using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Data.DTOs;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class FollowerConfiguration : IEntityTypeConfiguration<Follower>
    {
        public void Configure(EntityTypeBuilder<Follower> builder)
        {
            builder
                .HasOne(um => um.FollowerUser)
                .WithMany()
                .HasForeignKey(um => um.FollowerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(um => um.FollowingUser)
                .WithMany()
                .HasForeignKey(um => um.FollowingId)
                .OnDelete(DeleteBehavior.NoAction);

            List<Follower> followers = new();
            List<FollowerDTO>? dtos = GetMessageDTOs() ?? new();

            foreach (FollowerDTO dto in dtos)
            {
                Follower curr = Parse(dto);
                followers.Add(curr);
            }

            builder.HasData(followers);
        }

        private List<FollowerDTO>? GetMessageDTOs()
        {
            string text = File.ReadAllText("../SocialMedia.Infrastructure/Data/JSON/followers.json");
            
            List<FollowerDTO>? dtos = JsonSerializer.Deserialize<List<FollowerDTO>>(text);
            
            return dtos;
        }

        private Follower Parse(FollowerDTO dto)
        {
            Follower follower = new();

            follower.Id = dto.Id;
            follower.CreatedAt = dto.CreatedAt;
            follower.FollowerId = dto.FollowerId;
            follower.FollowingId = dto.FollowingId;

            return follower;
        }
    }
}