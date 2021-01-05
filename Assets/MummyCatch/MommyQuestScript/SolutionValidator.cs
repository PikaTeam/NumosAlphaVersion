using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SolutionValidator : MonoBehaviour
{
    [SerializeField] RandomFormula formula;
    [SerializeField] TMP_InputField uiInputField;
    [SerializeField] ModuloSolver solver;

    GameObject close;

    


    public void ValidateAnswer()
    {
        // Checks if the solution is true.
        // 1. Retrieve the text the user inputted into the the uiInputfield.
        // 2. Validate input (non empty, not too lengthy).
        // 3. Compute formula's solution with <TODO>
        // 4. Assert that user input equals the formula's solution.

        string userInput = uiInputField.text;

        if (IsValidInput(userInput, 5))
        {
            int solution = solver.Solve(formula);

            if (solution == Convert.ToInt32(userInput))
                OnCorrectAnswer();
            else OnWrongAnswer();
        }
    }

    private bool IsValidInput(string input, int maxLength)
    {
        // 1. does not exceed length or empty
        // 2. is contain only numberals

        bool isEmpty = input.Length == 0;
        bool isLengthy = input.Length > maxLength;
        bool isOnlyNumerals = IsOnlyNumerals(input);

        return (!isEmpty && !isLengthy && isOnlyNumerals);
    }   

    private bool IsOnlyNumerals(string input)
    {
        // The input must contain only numberals
        Regex onlyNumeralsRegex = new Regex(@"\d*",
             RegexOptions.Compiled | RegexOptions.IgnoreCase);

        bool isOnlyNumberals = onlyNumeralsRegex.IsMatch(input);

        return isOnlyNumberals;
    }

    private void OnCorrectAnswer()
    {
        Debug.Log("CORRECT ANSWER!");
        SingleToon.getInstance().curmoney.gain(100);
        SingleToon.getInstance().curscore.raise(300);
        SingleToon.getInstance().curmummycaght.get(1);

        GetComponent<CloseQuest>().Close();


        // 1. Player gains money.
        // 2. Player gains score points.
        // 3. Close quest.
    }

    private void OnWrongAnswer()
    {
        Debug.Log("WRONG ANSWER!");
        SingleToon.getInstance().curlife.damage(15);

        GetComponent<CloseQuest>().Close();
        // 1. Player lose health points.
        // 2. Close quest.
    }

    
   
}
