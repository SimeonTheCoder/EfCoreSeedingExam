using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Data.DTOs;
using SocialMedia.Infrastructure.Data.Models;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasOne(um => um.Receiver)
                .WithMany()
                .HasForeignKey(um => um.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(um => um.Sender)
                .WithMany()
                .HasForeignKey(um => um.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            List<Message> messages = new();
            List<MessageDTO>? dtos = GetMessageDTOs() ?? new();

            foreach (MessageDTO dto in dtos)
            {
                Message curr = Parse(dto);
                messages.Add(curr);
            }

            builder.HasData(messages);
        }

        private List<MessageDTO>? GetMessageDTOs()
        {
            string text = File.ReadAllText("../SocialMedia.Infrastructure/Data/JSON/messages.json");
            
            List<MessageDTO>? dtos = JsonSerializer.Deserialize<List<MessageDTO>>(text);
            
            return dtos;
        }

        private Message Parse(MessageDTO dto)
        {
            Message message = new();

            message.Id = dto.Id;
            message.Content = dto.Content;
            message.SenderId = dto.SenderId;
            message.ReceiverId = dto.ReceiverId;
            message.CreatedAt = dto.CreatedAt;
            message.Read = dto.Read;

            return message;
        }
    }
}