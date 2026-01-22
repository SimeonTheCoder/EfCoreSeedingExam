using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static SocialMedia.Infrastructure.Data.Constants.DbConstants.UserConstants;

namespace SocialMedia.Infrastructure.Data.DTOs
{
    public class UserDTO
    {
        [Required]
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("username")]
        [StringLength(MaxUsernameLength, MinimumLength = 4, ErrorMessage = "Invalid username!")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address!")]
        [JsonPropertyName("email")]
        [MaxLength(MaxEmailLength)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("avatar")]
        public string Avatar {get; set;} = string.Empty;

        [Required]
        [MaxLength(MaxBioLength)]
        [JsonPropertyName("bio")]
        public string Bio {get; set;} = string.Empty;

        [Required]
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt {get; set;}
    }
}