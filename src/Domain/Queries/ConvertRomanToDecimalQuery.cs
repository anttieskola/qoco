namespace QOCO.Domain.Queries;

public record ConvertRomanToDecimalQuery : IRequest<int>
{
    public required string RomanNumber { get; init; }
}

public class ConvertRomanToDecimalQueryHandler : IRequestHandler<ConvertRomanToDecimalQuery, int>
{
    public Task<int> Handle(ConvertRomanToDecimalQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
