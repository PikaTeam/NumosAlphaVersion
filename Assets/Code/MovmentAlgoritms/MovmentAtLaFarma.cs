using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovmentAtLaFarma : MonoBehaviour
{
    //jumping
    public float jumpForce = 10;
    public float jumpForceEffectByMomentomRatio;
    public float speed = 4f;

    //the invatory object
    public GameObject Instruction;
    private GameObject fordestroy;
    bool exist = false;

    //check if misson done
    bool done = LaFarmaBox.missiondone = false;

    //talking
    public TextMeshProUGUI textdisplay;

    public GameObject InvatoryForUSe;

    protected Vector3 NewPosition()
    {
        //leftMovement
        if (Input.GetKey(KeyPanel.MoveLeft))
        {
            return transform.position + Vector3.left * Time.deltaTime * speed;
        }

        //RightMovement
        else if (Input.GetKey(KeyPanel.MoveRight))
        {
            return transform.position + Vector3.right * Time.deltaTime * speed;
        }

        //DownMovement
        else if (Input.GetKey(KeyPanel.MoveDown))
        {
            return transform.position + Vector3.down * Time.deltaTime * speed;
        }

        //UpMovement
        else if (Input.GetKey(KeyPanel.MoveUp))
        {
            return transform.position + Vector3.up * Time.deltaTime * speed;
        }

        //click on a
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKey("a"))
        {
            SceneManager.LoadScene("LaFarmaChallange");
            return transform.position; //ToDo Pass into ohter secne
        }

        //click on b
        else if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("b"))
        {
            if (exist==false)
            {
                textdisplay.text = "אם אתה צריך עזרה או רוצה לעשות משהו אחר תקרא לי על ידי לחיצה על המקש X";
                fordestroy = Instantiate(Instruction);
                exist = true; 
            }

                

            return transform.position; //ToDo Pass into ohter secne
        }

        //click on x
        else if (Input.GetKeyDown(KeyCode.X) || Input.GetKey("x"))
        {
            if (exist == true)
            {
                Destroy(fordestroy);
                exist = false;
            }



            textdisplay.text = " <u> מר פפיון:  </u> שלום ברוכים הבאים למתפרה שלי, כיצד תרצו להנעים את זמנכם כאן?" + "\n" + "                  א . לעזור לי במשימה - לחצו על A" + "\n" + "                   ב. לקנות בחנות - לחצו על B                   " + "\n" + "                   ג. לבקש רמז - לחצו על C" + "\n" + "                   ד. להסתובב מסביב - לחצו על D";
            return transform.position; //ToDo Pass into ohter secne
        }

        //click on c
        else if (Input.GetKeyDown(KeyCode.C) || Input.GetKey("c"))
        {
            if (done == true)
            {
                textdisplay.text = "ברור שאשמח לעזור לך אחרי שעזרת לי, הדרך להציל את המלך היא להשיג את כל רכיבי השיקוי המפוזרים בממלכה, תוכל לדעת מה הם אם תדבר עם הנחשית במאפיה בהצלחה!";
            }
            else
                textdisplay.text = "מזג האוויר אפרורי היום כמעט כמו היחס הלא מתחשב שלך! אני לא יודע כלום בעניין. " + "\n" + "אם אתה מחפש אותי תלחץ על המקש R";
            return transform.position; //ToDo Pass into ohter secne
        }


        //click on d
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKey("d"))
        {
            textdisplay.text = "אם אתה צריך עזרה או רוצה לעשות משהו אחר תקרא לי על ידי לחיצה על המקש X";
            return transform.position; //ToDo Pass into ohter secne
        }

        //click on R
        else if (Input.GetKeyDown(KeyCode.R) || Input.GetKey("r"))
        {
            textdisplay.text = " <u> מר פפיון:  </u> שלום ברוכים הבאים למתפרה שלי, כיצד תרצו להנעים את זמנכם כאן?" + "\n" + "                  א . לעזור לי במשימה - לחצו על A" + "\n" + "                   ב. לקנות בחנות - לחצו על B                   " + "\n" + "                   ג. לבקש רמז - לחצו על C" + "\n" + "                   ד. להסתובב מסביב - לחצו על D";
            return transform.position; //ToDo Pass into ohter secne
        }

        //M key down -> open invatory
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(InvatoryForUSe);
            return transform.position;
        }


        else
        {
            return transform.position;
        }



    }



    // Update is called once per frame
    void Update()
    {
        transform.position = NewPosition();
    }
}

