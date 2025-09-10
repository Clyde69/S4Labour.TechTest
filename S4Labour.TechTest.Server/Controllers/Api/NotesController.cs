using Microsoft.AspNetCore.Mvc;
using S4Labour.TechTest.Server.Models;
using S4Labour.TechTest.Services;
using S4Labour.TechTest.Services.Models.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace S4Labour.TechTest.Server.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotesController : ControllerBase
	{
		private readonly IUserStorageService _userStorageService;
		private readonly ILogger _logger;

		public NotesController(IUserStorageService userStorageService, ILogger logger)
		{
			_userStorageService = userStorageService;
			_logger = logger;
		}

		[Route("GetNotesFor/{name}")]
		[HttpGet]
		[SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<UserNote>))]
		[SwaggerResponse(StatusCodes.Status204NoContent)]
		[SwaggerResponse(StatusCodes.Status500InternalServerError)]
		public IActionResult GetNotesForUser(string name)
		{
			try
			{
				var results = _userStorageService.Notes.Where(w => w.UserName == name);

				return results.Count() > 0 ? Ok(results) : NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError(-2, ex.Message);
				return StatusCode(500);
			}
		}

		[Route("AddNoteFor/{name}")]
		[HttpPost]
		[SwaggerResponse(StatusCodes.Status204NoContent)]
		[SwaggerResponse(StatusCodes.Status500InternalServerError)]
		public IActionResult AddNotesForUser(string name, [FromBody] NotePostModel note)
		{
			try
			{
				_userStorageService.Notes.Add(new UserNote(name, note.Note, DateTime.Now));

				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError(-2, ex.Message);
				return StatusCode(500);
			}
		}
	}
}
