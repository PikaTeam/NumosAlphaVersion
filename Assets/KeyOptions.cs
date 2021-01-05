using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyOptions : MonoBehaviour
{
    public TMP_Dropdown Options;
    public string KeyToChange;
    public KeyPanel keylink;
    
    public string[] KeyValues = new string[4] { "right", "left" , "up" , "down" };
    public List<string> KeyCharsValues = new List<string>();
    private void Start()
    {
        Options.ClearOptions();

        KeyCharsValues.Add("left");
        KeyCharsValues.Add("up");
        KeyCharsValues.Add("down");
        KeyCharsValues.Add("right");

        for (int i=97;i<123;i++)
        {
            KeyCharsValues.Add(((char)i).ToString());
        }

        //remove not to change keys
        KeyCharsValues.Remove("a");
        KeyCharsValues.Remove("b");
        KeyCharsValues.Remove("c");
        KeyCharsValues.Remove("d");
        KeyCharsValues.Remove("i");
        KeyCharsValues.Remove("m");
        KeyCharsValues.Remove("x");
        KeyCharsValues.Remove("r");






        Options.AddOptions(KeyCharsValues);
       
    }


    public void ChangeKey ()
    {
        string Pushed = Options.options[Options.value].text;

        switch (KeyToChange)
        {
            case"right":
                KeyPanel.MoveRight = Pushed;
                break;

            case "left":
                KeyPanel.MoveLeft = Pushed;
                break;

            case "up":
                KeyPanel.MoveUp = Pushed;
                break;

            case "down":
                KeyPanel.MoveDown = Pushed;
                break;

            case "take":
                KeyPanel.Take = Pushed;
                break;

            case "give":
                KeyPanel.Put = Pushed;
                break;

            case "throw":
                KeyPanel.ThrowBandage = Pushed;
                break;

            case "enter":
                KeyPanel.EnterToPlaces = Pushed;
                break;
        }
            






    }
    

}
