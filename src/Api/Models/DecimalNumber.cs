namespace QOCO.Api.Models;

/// <summary>
/// Response model when converting number to decimal
/// </summary>
public record DecimalNumber
{
    /// <summary>
    /// The decimal number
    /// </summary>
    public required int Value { get; set; }
}
