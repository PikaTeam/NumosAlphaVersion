using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class TalkingBox : MonoBehaviour
{

    public TextMeshProUGUI textdisplay;
    public string[] sentaence;
    public string san;

    //check if the player alredy done the task
    public bool missiondone = false;

    private int index;
    public float typingspeed = 4f;


    // Start is called before the first frame update
    void Start()
    {
        textdisplay.text = "הגעתם בהצלחה לממלכת נאמברין להציל את אחיכם - מספר חמש שהוכנס לצינוק בגלל שלא הצליח למנוע מהמלך אינסוף להפוך לדג." + "\n" + "על מנת לפתור את הברוך עליכם להסתובב ברחבי הממלכה לבצע משימות ולאסוף רמזים וחלקים שבאמצעותם תוכלו להסיר את הקללה מהמלך." + "\n" + "במידה ואתם נתקלים במומיות שליליות תהיו זהירים ותתרחקו מהן, אלה אם כן אתם מרגישים אמיצים ויכולים לזרוק לכיוונם נייר חניטה בלחיצה על B, על כל מומיה שתתפסו תקבלו נקודות. " + "\n" + "להסברים נוספים הקישו I, לעצירת המשחק הקישו P.";



        //StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Type()
    {
        foreach (char letter in sentaence[index].ToCharArray())
        {
            textdisplay.text = textdisplay.text + letter;
            yield return new WaitForSeconds(typingspeed);
        }
    }

    //LaFarma Conversion
    public void LaFarmaDialog()
    {
        char pushed;
        //begining sentance
        textdisplay.text = " <u> מר פפיון:  </u> שלום ברוכים הבאים למתפרה שלי, כיצד תרצו להנעים את זמנכם כאן?" + "\n" + "א. לעזור לי במשימה" + "\n" + "ב. לקנות משהו" + "\n" + "ג. לבקש רמז" + "\n" + "ד. להסתובב מסביב";
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


    //LaFarma Conversion
    public void GusteTasteDialog()
    {
        char pushed;
        //begining sentance
        textdisplay.text = "<u> הנחשה דאס:  </u> שלום ברוכים הבאים למאפייה שלי, התכבדו ותרגישו בנוח באוהלי הקט:?" + "\n" + "א. לעזור לי במשימה" + "\n" + "ב. לקנות משהו" + "\n" + "ג. לבקש רמז" + "\n" + "ד. להסתובב מסביב";
        pushed = CaseManger.getpushedkey();
        switch (pushed)
        {
            //if the player chose 'a' the task begin in the new scene
            case 'A':
                {
                    SceneManager.LoadScene("GuessTasteTabon");
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
                        textdisplay.text = "הבנתי, אתם מוניינים להציל את המלך, נתתי לכם יחד עם החלק של השיקוי גם רשימת מצרכים להכנתו, ככה שאתם יכולים לראות מה חסר לכם והיכן, בהצלחה!";
                    }
                    else
                        textdisplay.text = "אתה יודע מה אומרים אצלנו במצרים? חפש אותי במוצש בבוקר.";

                }
                break;

            case 'D':
                {
                    //the player can going in the shop
                    textdisplay.text = "שיהיה לך יום נעים, אם תרצה לטעום מהמטעמים או לשאול משהו תרגיש חופשי לפנות אלי";
                }
                break;


        }
    }

    public void show (string Strings)
    {
        textdisplay.text = Strings;
    }


}
