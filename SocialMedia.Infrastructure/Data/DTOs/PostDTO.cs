using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SocialMedia.Infrastructure.Data.Models;
using static SocialMedia.Infrastructure.Data.Constants.DbConstants.PostConstants;

namespace SocialMedia.Infrastructure.Data.DTOs
{
    public class PostDTO
    {
        [Required]
        [JsonPropertyName("id")]
        public string Id {get; set;} = string.Empty;

        [Required(ErrorMessage = "Post content is required!")]
        [MaxLength(MaxPostLength)]
        [JsonPropertyName("content")]
        public string Content {get; set;} = string.Empty;

        [JsonPropertyName("image")]
        public string Image {get; set;} = string.Empty;

        [Required]
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt {get; set;}

        [Required(ErrorMessage = "User is required!")]
        [JsonPropertyName("userId")]
        public string UserId {get; set;} = string.Empty;
        [ForeignKey(nameof(UserId))]
        public virtual User User {get; set;} = default!;
    }
}