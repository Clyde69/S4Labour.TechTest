using Microsoft.AspNetCore.Mvc;
using S4Labour.TechTest.Server.Models;
using S4Labour.TechTest.Services;
using S4Labour.TechTest.Services.Models.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace S4Labour.TechTest.Server.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserStorageService _userStorageService;
		private readonly ILogger _logger;

		public UserController(IUserStorageService userStorageService, ILogger logger)
		{
			_userStorageService = userStorageService;
			_logger = logger;
		}

		[Route("GetAll")]
		[HttpGet]
		[SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<User>))]
		[SwaggerResponse(StatusCodes.Status204NoContent)]
		[SwaggerResponse(StatusCodes.Status500InternalServerError)]
		public IActionResult GetUsers()
		{
			try
			{
				var results = _userStorageService.AllUsers;

				results.ForEach(result => {
					result.Favourite = _userStorageService.FavouriteUsers.Any(w => w == result.UserName);
				});

				return results.Count > 0 ? Ok(results) : NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError(-1, ex.Message);
				return StatusCode(500);
			}
		}

		[Route("Favourites")]
		[HttpGet]
		[SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<User>))]
		[SwaggerResponse(StatusCodes.Status204NoContent)]
		[SwaggerResponse(StatusCodes.Status500InternalServerError)]
		public IActionResult GetFavouriteUsers()
		{
			try
			{
				var results = _userStorageService.AllUsers.Where(w => _userStorageService.FavouriteUsers.Contains(w.UserName));

				results.All(result => {
					result.Favourite = _userStorageService.FavouriteUsers.Any(w => w == result.UserName);
					return true;
				});

				return results.Count() > 0 ? Ok(results) : NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError(-1, ex.Message);
				return StatusCode(500);
			}
		}

		[Route("Favourite/{name}")]
		[HttpPatch]
		[SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
		[SwaggerResponse(StatusCodes.Status400BadRequest)]
		[SwaggerResponse(StatusCodes.Status500InternalServerError)]
		public IActionResult UserFavourite(string name, FavouritePatchModel newValue)
		{
			if(!_userStorageService.AllUsers.Any(w => w.UserName == name))
			{
				return BadRequest($"No user with a username of {name} exists.");
			}

			try
			{
				if (newValue.NewValue && !_userStorageService.FavouriteUsers.Exists(w => w == name))
				{
					_userStorageService.FavouriteUsers.Add(name);
					return Ok(true);
				}
				else if(_userStorageService.FavouriteUsers.Exists(w => w == name))
				{
					_userStorageService.FavouriteUsers.Remove(name);
					return Ok(false);
				}
				return BadRequest("Something went wrong.");
			}
			catch (Exception ex)
			{
				_logger.LogError(-1, ex.Message);
				return StatusCode(500);
			}
		}
	}
}
