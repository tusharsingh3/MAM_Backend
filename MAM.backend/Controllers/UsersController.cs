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
    public IEnumerable<Users> Get()
    {
		_userManager.GetAll();

        return Enumerable.Range(1, 5).Select(index => new Users
		{
			FirstName = string.Empty,
			LastName = string.Empty,
			Age = 10
		})
		.ToArray();

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