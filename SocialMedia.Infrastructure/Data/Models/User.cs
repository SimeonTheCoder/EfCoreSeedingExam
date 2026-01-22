using System.ComponentModel.DataAnnotations;
using static SocialMedia.Infrastructure.Data.Constants.DbConstants.UserConstants;

namespace SocialMedia.Infrastructure.Data.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxUsernameLength)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxEmailLength)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Avatar {get; set;} = string.Empty;

        [Required]
        [MaxLength(MaxBioLength)]
        public string Bio {get; set;} = string.Empty;

        [Required]
        public DateTime CreatedAt {get; set;}
    }
}