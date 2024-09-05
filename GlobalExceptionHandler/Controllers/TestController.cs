using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalExceptionHandler.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{

		[HttpGet("")]
		public async Task<ActionResult> GetAll()
		{
			throw new Exception("Excepiton: Test Hatası");
			return Ok(new[] { 1, 2, 3 });
		}

		[HttpGet("id")]
		public async Task<ActionResult> GetById(int Id)
		{
			throw new NotImplementedException("This Method is notimplemented");
		}
	}
}
