using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public class TextAsModularFormula : IModularFormula
{
    private string formulaText;
    public TextAsModularFormula(string text)
    {
        formulaText = text;
    }

    public IEnumerable<int> LHSNumbers()
    {
        Regex signedNumbersRegex = new Regex(@"(\+|\-)(\s*\d+)");

        IList<int> signedNumbers = new List<int>();
        foreach (Match match in signedNumbersRegex.Matches(formulaText))
        {
            int sign = (match.Groups[1].Value == "+") ? 1 : -1;
            int number = Convert.ToInt32(match.Groups[2].Value);

            signedNumbers.Add(sign * number);
        }

        return signedNumbers;
    }

    public int Modulo()
    {
        Regex moduloValueRegex = new Regex(@"\(%\s*(\d)\)");

        int modValue = Convert.ToInt32(
                        moduloValueRegex.Match(formulaText)
                                        .Groups[1]
                                        .Value);

        return modValue;
    }
}

