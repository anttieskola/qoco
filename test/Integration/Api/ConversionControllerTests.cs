namespace QOCO.Test.Integration;

public class ConversionControllerTests
{
    [Fact]
    public void Ok()
    {
        var mockSender = new Mock<ISender>();
        mockSender.Setup(x => x.Send(It.IsAny<ConvertRomanToDecimalQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(42);
        var controller = new ConvertRomanToDecimal(mockSender.Object);
        var result = controller.RomanToDecimal(new RomanNumber { Value = "I" }).Result;
        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.IsType<DecimalNumber>(okResult.Value);
    }

    [Fact]
    public void Error()
    {
        var mockSender = new Mock<ISender>();
        mockSender.Setup(x => x.Send(It.IsAny<ConvertRomanToDecimalQuery>(), It.IsAny<CancellationToken>())).ThrowsAsync(new ValidationException("error"));
        var controller = new ConvertRomanToDecimal(mockSender.Object);
        var result = controller.RomanToDecimal(new RomanNumber { Value = "I" }).Result;
        Assert.IsType<BadRequestObjectResult>(result);
        var errorResult = result as BadRequestObjectResult;
        Assert.NotNull(errorResult);
    }
}