using Microsoft.AspNetCore.Mvc;

namespace Mathematics.Multiplication.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class MultiplicationController : ControllerBase
{
    [HttpGet]
    public ActionResult<int> MultiInteger(int left, int right)
    {
        var result = left * right;

        return Ok(new { result });
    }

    [HttpGet]
    public ActionResult<double> MultiDouble(double left, double right)
    {
        var result = left * right;

        return Ok(new { result });

    }
}


