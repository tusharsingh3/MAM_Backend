using Microsoft.AspNetCore.Mvc;

namespace MAM.backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
	private readonly ILogger<UsersController> _logger;

	public UsersController(ILogger<UsersController> logger)
	{
		_logger = logger;
	}

	[HttpGet("GetUsers")]
    public IEnumerable<Users> Get()
    {
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