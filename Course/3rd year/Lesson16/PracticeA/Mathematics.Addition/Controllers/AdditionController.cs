using Microsoft.AspNetCore.Mvc;

namespace Mathematics.Addition.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AdditionController : ControllerBase
{
    [HttpGet]
    public ActionResult<int> SumInteger(int left, int right)
    {
        var result = left + right;

        return Ok(new { result });
    }

    [HttpGet]
    public ActionResult<double> SumDouble(double left, double right)
    {
        var result = left + right;

        return Ok(new { result });
    }
}


