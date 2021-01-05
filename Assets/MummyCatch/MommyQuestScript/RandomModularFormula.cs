using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RandomModularFormula : IModularFormula
{

    private IModularFormula formula;

    public RandomModularFormula(int length = 2, int minModulo = 2, int maxModulo = 15, int minNumber = -15, int maxNumber = 15)
    {
        int modulo = UnityEngine.Random.Range(minModulo, maxModulo + 1);

        int[] numbers = new int[length];
        for (int i = 0; i < length; i++)
        {
            int number = UnityEngine.Random.Range(minNumber, maxNumber + 1);
            if (number == 0)
                number = UnityEngine.Random.Range(1, maxNumber + 1);
            numbers[i] = number;
        }

        formula = new ModularFormula(modulo, numbers);
    }
    public IEnumerable<int> LHSNumbers()
    {
        return formula.LHSNumbers();
    }

    public int Modulo()
    {
        return formula.Modulo();
    }

    public override string ToString()
    {
        // create text
        string text = "";
        foreach (int num in LHSNumbers())
        {
            char sign = (num >= 0) ? '+' : '-';
            text += sign + " ";
            text += Math.Abs(num);
            text += " ";
        }

        text += "(mod " + Modulo() + ")";

        return text;
    }

}

