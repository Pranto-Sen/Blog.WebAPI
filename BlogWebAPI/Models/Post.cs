namespace BlogWebAPI.Models
{
	public class Post
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
        public DateTime PublishTime { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

		public List<Comment> Comments { get; set; }
	}
}
