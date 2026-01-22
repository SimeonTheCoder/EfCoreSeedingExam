using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Data.DTOs;
using SocialMedia.Infrastructure.Data.Models;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            List<User> users = new();
            List<UserDTO>? dtos = GetUserDTOs() ?? new();

            foreach (UserDTO dto in dtos)
            {
                User curr = Parse(dto);
                users.Add(curr);
            }

            //Console.WriteLine(users.Count);
            //Console.WriteLine(users.Distinct().Count());
            builder.HasData(users);
        }

        private List<UserDTO>? GetUserDTOs()
        {
            string text = File.ReadAllText("../SocialMedia.Infrastructure/Data/JSON/users.json");
            
            List<UserDTO>? dtos = JsonSerializer.Deserialize<List<UserDTO>>(text);
            
            return dtos;
        }

        private User Parse(UserDTO dto)
        {
            User user = new();

            user.Id = dto.Id;
            user.Username = dto.Username;
            user.Email = dto.Email;
            user.CreatedAt = dto.CreatedAt;
            user.Bio = dto.Bio;
            user.Avatar = dto.Avatar;

            return user;
        }
    }
}