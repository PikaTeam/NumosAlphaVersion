//using System;
using System.Collections.Generic;
using UnityEngine;
//using org.mariuszgromada.math.mxparser;
using System.Linq;

public class ModuloSolver : MonoBehaviour
{
    public int Solve(RandomFormula formula)
    {
        IEnumerable<int> numbers = formula.LHSNumbers();
        int sum = numbers.Sum();
        int mod = formula.Modulo();

        return Solve(sum, mod);
    }

    public int Solve(int lhs, int mod)
    {
        int result = lhs % mod;

        return PositiveCanonicalResidue(result, mod);
    }

    private int PositiveCanonicalResidue(int result, int mod)
    {
        if (result < 0)
            return result + mod;
        else return result;
    }

}

