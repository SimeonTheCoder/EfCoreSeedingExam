using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SocialMedia.Infrastructure.Data.Models;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class Follower
    {
        public Follower()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id {get; set;} = string.Empty;

        [Required]
        public DateTime CreatedAt {get; set;}

        [Required]
        public string FollowerId {get; set;} = string.Empty;
        [ForeignKey(nameof(FollowerId))]
        public virtual User FollowerUser {get; set;} = default!;

        [Required]
        public string FollowingId {get; set;} = string.Empty;
        [ForeignKey(nameof(FollowingId))]
        public virtual User FollowingUser {get; set;} = default!;
    }
}