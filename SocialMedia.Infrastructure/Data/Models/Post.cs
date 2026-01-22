using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SocialMedia.Infrastructure.Data.Constants.DbConstants.PostConstants;

namespace SocialMedia.Infrastructure.Data.Models
{
    public class Post
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id {get; set;} = string.Empty;

        [Required]
        [MaxLength(MaxPostLength)]
        public string Content {get; set;} = string.Empty;

        [Required]
        public string Image {get; set;} = string.Empty;

        [Required]
        public DateTime CreatedAt {get; set;}

        [Required]
        public string UserId {get; set;} = string.Empty;
        [ForeignKey(nameof(UserId))]
        public virtual User User {get; set;} = default!;
    }
}