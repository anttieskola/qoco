namespace QOCO.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ConversionController : ControllerBase
{
    private readonly ISender _sender;

    public ConversionController(
        ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(Name = "RomanToDecimal")]
    public async Task<IActionResult> RomanToDecimal([FromBody] RomanNumber romanNumber)
    {
        try
        {
            var result = await _sender.Send(new ConvertRomanToDecimalQuery { RomanNumber = romanNumber.Value });
            return Ok(new DecimalNumber { Value = result });
        }
        catch (ValidationException ve)
        {
            return BadRequest(ve.Message);
        }
    }
}
