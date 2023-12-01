namespace QOCO.Domain.Queries;

public record ConvertRomanToDecimalQuery : IRequest<int>, IValidatableObject
{
    /// <summary>
    /// Valid characters: IiVvXxLlCcDdMm
    /// </summary>
    public required string RomanNumber { get; init; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(RomanNumber))
        {
            yield return new ValidationResult("RomanNumber is required", new[] { nameof(RomanNumber) });
        }
        else if (!RomanNumber.All(c => "IiVvXxLlCcDdMm".Contains(c)))
        {
            yield return new ValidationResult("RomanNumber contains invalid characters", new[] { nameof(RomanNumber) });
        }
        else if (RomanNumber.Length > 256)
        {
            yield return new ValidationResult("RomanNumber is too long", new[] { nameof(RomanNumber) });
        }
    }
}

public class ConvertRomanToDecimalQueryHandler : IRequestHandler<ConvertRomanToDecimalQuery, int>
{
    public Task<int> Handle(ConvertRomanToDecimalQuery request, CancellationToken cancellationToken)
    {
        Validator.ValidateObject(request, new ValidationContext(request), true);
        var romanNumber = request.RomanNumber.ToUpper();

        // make a list of decimals
        var decimals = new List<int>();
        foreach (var romanCharacter in romanNumber)
        {
            decimals.Add(GetRomanNumberDecimalValue(romanCharacter));
        }

        // calculate the overall value using list
        // using the order of the list to determine
        // if we need to add or subtract
        var decimalValue = 0;
        for (var i = 0; i < decimals.Count; i++)
        {
            var value = decimals[i];
            var rest = decimals.Skip(i);
            if (rest.Any(x => x > value))
                decimalValue -= value;
            else
                decimalValue += value;
        }
        return Task.FromResult(decimalValue);
    }

    private static int GetRomanNumberDecimalValue(char rc)
    {
        return rc switch
        {
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            'C' => 100,
            'D' => 500,
            'M' => 1000,
            _ => throw new ValidationException($"Invalid character:{rc}")
        };
    }
}
