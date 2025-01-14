namespace BlogWebAPI.Models
{
	public class Comment
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string CommentText { get; set; }
		public DateTime PublishTime { get; set; }

		public Guid PostId { get; set; }
		public Post Post { get; set; }
		public Guid UserId { get; set; }
		public User User { get; set; }

	}
}
