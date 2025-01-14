using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebAPI.Models.Domain
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CommentText { get; set; }
        public DateTime PublishTime { get; set; } = DateTime.Now;

        [ForeignKey(nameof(PostId))]
        public Guid PostId { get; set; }
        public Post Post { get; set; }

        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }
        public User User { get; set; }



    }
}
