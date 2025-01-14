using System.ComponentModel.DataAnnotations;

namespace BlogWebAPI.Models
{
	public class User
	{
		[Key]
        public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
        public string MobileNo { get; set; }
        public string UserName { get; set; }
		public string Password { get; set; }
		public List<Post> Posts { get; set; }
		public List<Comment> Comments { get; set; }
	}
}
