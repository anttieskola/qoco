namespace QOCO.Api.Models;

/// <summary>
/// Request to convert a roman number to decimal number
/// </summary>
public record RomanNumber
{
    /// <summary>
    /// The roman number to convert, valid characters are IiVvXxLlCcDdMm
    /// Maximum length is 256 characters
    /// </summary>
    [Required]
    [Description("The roman number to convert, valid characters are IiVvXxLlCcDdMm")]
    [MaxLength(256)]
    public required string Value { get; set; }
}
