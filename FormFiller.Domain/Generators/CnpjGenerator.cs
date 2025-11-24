using System;

namespace FormFiller.Domain.Generators;

public class CnpjGenerator : IGen
{
    public string Name { get; } = "cnpj";

    public List<string>? Params { get; } = null;

    public string Generate()
    {
        var rand = new Random();
        var firstEightNumbers = rand.Next(0, 100000000).ToString("D8");
        var middleDigits = rand.Next(9).ToString("D4");
        var firstValidatorDigit = CalculateValidatorDigit(firstEightNumbers + middleDigits).ToString("D1");
        var secondValidatorDigit = CalculateValidatorDigit(firstEightNumbers + middleDigits + firstValidatorDigit).ToString("D1");
        var formattedFirstEigthNumbers = string.Join(".", firstEightNumbers.Substring(0, 2), firstEightNumbers.Substring(2, 5), firstEightNumbers.Substring(5));
        return $"{formattedFirstEigthNumbers}/{middleDigits}-{firstValidatorDigit}{secondValidatorDigit}";
    }

    private int CalculateValidatorDigit(string previousDigits)
    {
        var multipliers = new List<int> { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        var firstIndex = previousDigits.Length == 13 ? 0 : 1;
        var totalSum = 0;
        for (int i = firstIndex; i < previousDigits.Length; i++)
        {
            totalSum += previousDigits[i] * multipliers[i];
        }
        if (totalSum % 11 < 2)
        {
            return 0;
        }
        return 11 - (totalSum % 11);
    }
}
