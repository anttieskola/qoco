namespace QOCO.Api.Controllers;

/// <summary>
/// Controller to convert number formats
/// </summary>
[ApiController]
[Route("[controller]")]
public class ConvertRomanToDecimal : ControllerBase
{
    private readonly ISender _sender;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="sender">MediatR</param>
    public ConvertRomanToDecimal(
        ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Convert a decimal number to roman number
    /// </summary>
    /// <param name="romanNumber"></param>
    /// <returns></returns>
    [HttpPost(Name = "RomanToDecimal")]
    [ProducesResponseType(typeof(DecimalNumber), StatusCodes.Status200OK)]
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
