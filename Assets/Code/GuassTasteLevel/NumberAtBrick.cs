using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberAtBrick : MonoBehaviour
{
    public int NumAtBrick()
    {
        TextMeshProUGUI textfind;
        int NumberOfBrick;
        textfind = this.GetComponentInChildren<TextMeshProUGUI>();
        NumberOfBrick = Convert.ToInt32(textfind.text);
        Debug.Log("i am a: " + NumberOfBrick);
        return NumberOfBrick;
    }

}
