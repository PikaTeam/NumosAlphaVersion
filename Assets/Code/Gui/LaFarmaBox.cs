using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class LaFarmaBox : MonoBehaviour
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
        
        //StartCoroutine(Type());
        char pushed;
        //begining sentance
        textdisplay.text = " <u> מר פפיון:  </u> שלום ברוכים הבאים למתפרה שלי, כיצד תרצו להנעים את זמנכם כאן?" + "\n" + "                  א . לעזור לי במשימה - לחצו על A" + "\n" + "                   ב. לקנות בחנות - לחצו על B                   " + "\n" + "                   ג. לבקש רמז - לחצו על C" + "\n" + "                   ד. להסתובב מסביב - לחצו על D";
        pushed = CaseManger.getpushedkey();
        switch (pushed)
        {
            //if the player chose 'a' the task begin in the new scene
            case 'A':
                {
                    SceneManager.LoadScene("LaFarmaChallange");
                }
                break;

            //if the player chose 'b'
            case 'B':
                {
                    //then will be open the shop invatory and he could buy someting
                    SceneManager.LoadScene("LaFarmaChallange");//temporeryhere
                }
                break;

            //if the player chose 'b'
            case 'C':
                {
                    //check if the mission alredy done, if true it gave clue, if false it dosent.
                    if (missiondone == true)
                    {
                        textdisplay.text = "ברור שאשמח לעזור לך אחרי שעזרת לי, הדרך להציל את המלך היא להשיג את כל רכיבי השיקוי המפוזרים בממלכה, תוכל לדעת מה הם אם תדבר עם הנחשית במאפיה בהצלחה!";
                    }
                    else
                        textdisplay.text = "מזג האוויר אפרורי היום כמעט כמו היחס הלא מתחשב שלך! אני לא יודע כלום בעניין.";

                }
                break;

            case 'D':
                {
                    //the player can going in the shop
                    textdisplay.text = "אני מקווה שהחנות שלי תבושם לך, אם אתה צריך עזרה או משהו תרגיש חופשי לפנות אלי שוב.";
                }
                break;


        }
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
