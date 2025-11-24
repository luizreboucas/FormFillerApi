using System;
using System.Collections.Generic;

namespace FormFiller.Domain.Generators;

public class CpfGenerator : IGen
{
    public string Name { get; } = "cpf";

    public List<string>? Params => null;

    public string Generate()
    {
        var rand = new Random();
        var firstNineDigits = rand.Next(0, 1000000000).ToString("D9");
        var firstValidatorDigit = CalculateValidatorDigit(firstNineDigits).ToString("D1");
        var secondValidatorDigit = CalculateValidatorDigit(firstNineDigits + firstValidatorDigit).ToString("D1");
        var formattedFirstNineDigits = string.Join(".", firstNineDigits.Substring(0, 3), firstNineDigits.Substring(3, 3), firstNineDigits.Substring(6, 3));
        return $"{formattedFirstNineDigits}-{firstValidatorDigit}{secondValidatorDigit}";
    }

    public int CalculateValidatorDigit(string firstDigits)
    {
        int totalSum = 0;
        for (int i = 0; i < firstDigits.Length; i++)
        {
            int digit = firstDigits[i];
            if (firstDigits.Length == 9)
            {
                totalSum += digit * (10 - i);
                continue;
            }
            totalSum += digit * (11 - i);
        }
        if (totalSum % 11 < 2)
        {
            return 0;
        }
        return 11 - (totalSum % 11);
    }
}
