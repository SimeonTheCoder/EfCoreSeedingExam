using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SocialMedia.Infrastructure.Data.DTOs
{
    public class FollowerDTO
    {
        [Required]
        [JsonPropertyName("id")]
        public string Id {get; set;} = string.Empty;

        [Required]
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt {get; set;}

        [Required]
        [JsonPropertyName("followerId")]
        public string FollowerId {get; set;} = string.Empty;

        [Required]
        [JsonPropertyName("followingId")]
        public string FollowingId {get; set;} = string.Empty;
    }
}