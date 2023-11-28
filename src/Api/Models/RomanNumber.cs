namespace QOCO.Api.Models;

public record RomanNumber
{
    [Required]
    [Description("The roman number to convert, valid characters are IiVvXxLlCcDdMm")]
    public required string Value { get; set; }
}
