using Microsoft.AspNetCore.Mvc;

namespace CaseBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { mensagem = "Minha primeira API em .NET!" });
    }
}
