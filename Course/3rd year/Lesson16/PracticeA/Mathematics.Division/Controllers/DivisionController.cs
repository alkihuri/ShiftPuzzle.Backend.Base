using Microsoft.AspNetCore.Mvc;

namespace Mathematics.Division.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class DivisionController : ControllerBase
{
    [HttpGet]
    public ActionResult<int> DivisionInteger(int left, int right)
    {
        if (right == 0)
            return BadRequest("Деление на 0");

        var result = left / right;

        return Ok(new { result });
    }

    [HttpGet]
    public ActionResult<double> DivisionDouble(double left, double right)
    {
        if (right == 0)
            return BadRequest("Деление на 0");

        var result = left / right;

        return Ok(new { result });

    }
}


