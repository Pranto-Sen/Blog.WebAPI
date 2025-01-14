using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebAPI.Models.Domain
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishTime { get; set; } = DateTime.Now;

        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }
        public User User { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
