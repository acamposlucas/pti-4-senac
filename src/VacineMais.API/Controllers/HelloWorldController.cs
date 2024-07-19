using Microsoft.AspNetCore.Mvc;

namespace VacineMais.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorldController
{
    [HttpGet]
    public string Get()
    {
        return "Hello World";
    }
}
