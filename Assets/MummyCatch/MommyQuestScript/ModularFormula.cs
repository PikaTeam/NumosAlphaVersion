using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ModularFormula : IModularFormula
{
    private int modulo;
    private IEnumerable<int> numbers;

    public ModularFormula(int modulo, params int[] numbers) 
    {
        this.modulo = modulo;
        this.numbers = numbers;
    }



    public IEnumerable<int> LHSNumbers()
    {
        return numbers;
    }

    public int Modulo()
    {
        return modulo;
    }
}

