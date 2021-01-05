using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuastusTalk : MonoBehaviour
{
    public TextMeshProUGUI textdisplay;
    public string[] sentaence;
    public string san;

    //check if the player alredy done the task
    public static bool missiondone = false;

    private int index;
    public float typingspeed = 4f;


    // Start is called before the first frame update
    void Start()
    {
     char pushed;
    //begining sentance
    textdisplay.text = "<u> הנחשה דאס:  </u> שלום ברוכים הבאים למאפייה שלי, התכבדו ותרגישו בנוח באוהלי הקט?" + "\n" + "                        א. לעזור לי במשימה - יש ללחוץ על A" + "\n" + "                        ב. לקנות משהו - יש ללחוץ על B" + "\n" + "                        ג. לבקש רמז - יש ללחוץ על C" + "\n" + "                        ד. להסתובב מסביב - יש ללחוץ על D";
     pushed = CaseManger.getpushedkey();
    }

    IEnumerator Type()
    {
        foreach (char letter in sentaence[index].ToCharArray())
        {
            textdisplay.text = textdisplay.text + letter;
            yield return new WaitForSeconds(typingspeed);
        }
    }

    public void show(string Strings)
    {
        textdisplay.text = Strings;
    }
}
