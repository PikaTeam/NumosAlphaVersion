using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Text.RegularExpressions;
using System;

public class RandomFormula : MonoBehaviour
{
    [SerializeField] public IModularFormula formula;
    [SerializeField] private TextMeshProUGUI guiText;

    private void Start()
    {
        formula = new RandomModularFormula(UnityEngine.Random.Range(2,3+1));
        guiText.text = formula.ToString() + " =";
    }

    public IEnumerable<int> LHSNumbers()
    {
        return formula.LHSNumbers();
    }

    public int Modulo()
    {
        return formula.Modulo();
    }


}

