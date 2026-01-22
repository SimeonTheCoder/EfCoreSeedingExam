using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SocialMedia.Infrastructure.Data.DTOs
{
    public class MessageDTO
    {
        [Required]
        [JsonPropertyName("id")]
        public string Id {get; set;} = string.Empty;

        [Required(ErrorMessage = "Content is required!")]
        [JsonPropertyName("content")]
        [MaxLength(2000, ErrorMessage = "Content must be under 2000 symbols!")]
        public string Content {get; set;} = string.Empty;

        [Required]
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt {get; set;}

        [Required]
        [JsonPropertyName("read")]
        public bool Read {get; set;} = false;

        [Required]
        [JsonPropertyName("senderId")]
        public string SenderId {get; set;} = string.Empty;

        [Required]
        [JsonPropertyName("receiverId")]
        public string ReceiverId {get; set;} = string.Empty;
    }
}