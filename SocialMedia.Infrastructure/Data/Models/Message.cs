using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Infrastructure.Data.Models
{
    public class Message
    {
        public Message()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id {get; set;} = string.Empty;

        [Required]
        [MaxLength(2000)]
        public string Content {get; set;} = string.Empty;

        [Required]
        public DateTime CreatedAt {get; set;}

        [Required]
        public bool Read {get; set;} = false;

        [Required]
        public string SenderId {get; set;} = string.Empty;
        [ForeignKey(nameof(SenderId))]
        public virtual User Sender {get; set;} = default!;

        [Required]
        public string ReceiverId {get; set;} = string.Empty;
        [ForeignKey(nameof(ReceiverId))]
        public virtual User Receiver {get; set;} = default!;
    }
}