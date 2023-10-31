using MAM.backend.Model;
using MAM.backend.Service.ServiceManager;
using Microsoft.AspNetCore.Mvc;

namespace MAM.backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
	private readonly ILogger<UsersController> _logger;
	private readonly UserManager _userManager;

    public UsersController(ILogger<UsersController> logger, UserManager userManager)
	{
		_logger = logger;
		_userManager = userManager;
	}

	[HttpGet("GetUsers")]
    public IActionResult Get()
    {
		List<User> result = new List<User>();
		try
		{
			result =  _userManager.GetAll();
		}
		catch (Exception ex)
		{
			Console.WriteLine($"ERROR IN GET_ALL_BALL_CHANGE :: EXCEPTION MESSAGE :: {ex.Message}");
		}
		return Ok(result);

	}

	[HttpPost(Name = "PostUser")]
	public IEnumerable<Users> Post()
	{
		return Enumerable.Range(1, 5).Select(index => new Users
		{
			FirstName = "test",
			LastName = string.Empty,
			Age = 10
		})
		.ToArray();

	}
}