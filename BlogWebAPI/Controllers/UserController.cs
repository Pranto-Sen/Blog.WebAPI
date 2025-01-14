using BlogWebAPI.Data;
using BlogWebAPI.Models.Domain;
using BlogWebAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly BlogDbContext dbContext;

		public UserController(BlogDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

        [HttpGet]
		public IActionResult GetAll()
		{
			var users = dbContext.Users.ToList();

			var userDto = new List<UserDTO>();
			foreach (var user in users)
			{
				userDto.Add(new UserDTO()
				{
					Id = user.Id,
					Name = user.Name,
					Email = user.Email,
					MobileNo = user.MobileNo,
				});
			}
			return Ok(userDto);
		}

		[HttpGet]
		[Route("{id}")]
		public IActionResult GetById(Guid id)
		{
			var userDomain = dbContext.Users.Find(id);
			if (userDomain == null)
			{
				return NotFound();
			}

			var userDto = new UserDTO
			{
				Id = userDomain.Id,
				Name = userDomain.Name,
				Email = userDomain.Email,
				MobileNo = userDomain.MobileNo,
			};

			return Ok(userDto);
		}

		[HttpPost]
		public IActionResult Create(AddUserDTO addUserDto)
		{
			var userDomainModel = new User
			{
				Name = addUserDto.Name,
				Email = addUserDto.Email,
				MobileNo = addUserDto.MobileNo,
				UserName = addUserDto.UserName,
				Password = addUserDto.Password
			};
			dbContext.Users.Add(userDomainModel);
			dbContext.SaveChanges();

			var userDTO = new UserDTO
			{
				Id = userDomainModel.Id,
				Name = userDomainModel.Name,
				Email = userDomainModel.Email,
				MobileNo = userDomainModel.MobileNo,
			};
			return Ok(userDTO);
			
		}

		[HttpPut]
		[Route("{id}")]
		public IActionResult Update(Guid id, AddUserDTO addUserDto)
		{
			var userDomainModel = dbContext.Users.FirstOrDefault(x => x.Id == id);
			if (userDomainModel == null)
			{
				return NotFound();
			}

			userDomainModel.Name = addUserDto.Name;
			userDomainModel.Email = addUserDto.Email;
			userDomainModel.MobileNo = addUserDto.MobileNo;
			userDomainModel.UserName = addUserDto.UserName;
			userDomainModel.Password = addUserDto.Password;

			dbContext.SaveChanges();

			var userDTO = new UserDTO
			{
				Id = userDomainModel.Id,
				Name = userDomainModel.Name,
				Email = userDomainModel.Email,
				MobileNo = userDomainModel.MobileNo,
			};
			return Ok(userDTO);
		}

		[HttpDelete]
		[Route("{id}")]
		public IActionResult Delete(Guid id)
		{
			var userDomainModel = dbContext.Users.FirstOrDefault(x => x.Id ==id);
			if (userDomainModel == null) 
			{ 
			return NotFound();
			}
			dbContext.Remove(userDomainModel);
			dbContext.SaveChanges();
			return Ok("Delete successfully");
		}
	}
}
