namespace QOCO.Test.Unit;

public class ConvertRomanToDecimalQueryTests
{

    [Theory]
    [InlineData("I", 1)]
    [InlineData("II", 2)]
    [InlineData("III", 3)]
    [InlineData("IV", 4)]
    [InlineData("V", 5)]
    [InlineData("VI", 6)]
    [InlineData("VII", 7)]
    [InlineData("VIII", 8)]
    [InlineData("IX", 9)]
    [InlineData("X", 10)]
    [InlineData("XI", 11)]
    [InlineData("XII", 12)]
    [InlineData("L", 50)]
    [InlineData("LXVII", 67)]
    [InlineData("C", 100)]
    [InlineData("CCLVI", 256)]
    [InlineData("D", 500)]
    [InlineData("DCCXXXII", 732)]
    [InlineData("DCCXCIV", 794)]
    [InlineData("M", 1000)]
    [InlineData("MMMMMMMMMCDXLIV", 9444)]
    [InlineData("MMMMMMMMMMMMMMMMMMMMMMMCDXV", 23415)]

    public async Task Tests(string romanNumber, int decimalNumber)
    {
        // Arrange
        var handler = new ConvertRomanToDecimalQueryHandler();

        // Act
        var result = await handler.Handle(new ConvertRomanToDecimalQuery { RomanNumber = romanNumber }, CancellationToken.None);

        // Assert
        Assert.Equal(decimalNumber, result);
    }

    [Fact]
    public async Task InvalidCharacters()
    {
        // Arrange
        var handler = new ConvertRomanToDecimalQueryHandler();

        // Act
        await Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await handler.Handle(new ConvertRomanToDecimalQuery { RomanNumber = string.Empty }, CancellationToken.None);
        });

        await Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await handler.Handle(new ConvertRomanToDecimalQuery { RomanNumber = "antti" }, CancellationToken.None);
        });
    }
}
