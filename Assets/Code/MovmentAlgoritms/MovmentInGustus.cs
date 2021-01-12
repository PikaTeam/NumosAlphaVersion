using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovmentInGustus : MonoBehaviour
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
    public TMPro.TextMeshProUGUI textdisplay;

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

        //click on A
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKey("a"))
        {
                SceneManager.LoadScene("Guasstustry2");
                return transform.position; //ToDo Pass into ohter secne
            }

        //click on b
        else if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("b"))
        {
            if (exist == false)
            {
                textdisplay.text = "אני חוזרת לשמור על האש, אם אתה מחפש אותי קרא לי על ידי לחיצה על X";
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



            textdisplay.text = "<u> הנחשה דאס:  </u> שלום ברוכים הבאים למאפייה שלי, התכבדו ותרגישו בנוח באוהלי הקט?" + "\n" + "                        א. לעזור לי במשימה - יש ללחוץ על A" + "\n" + "                        ב. לקנות משהו - יש ללחוץ על B" + "\n" + "                        ג. לבקש רמז - יש ללחוץ על C" + "\n" + "                        ד. להסתובב מסביב - יש ללחוץ על D";
            return transform.position; //ToDo Pass into ohter secne
        }

        //click on c
        else if (Input.GetKeyDown(KeyCode.C) || Input.GetKey("c"))
        {
            if (done == true)
            {
                textdisplay.text = "הבנתי, אתם מוניינים להציל את המלך, נתתי לכם יחד עם החלק של השיקוי גם רשימת מצרכים להכנתו, ככה שאתם יכולים לראות מה חסר לכם והיכן, בהצלחה!";
            }
            else
                textdisplay.text = "אתה יודע מה אומרים אצלנו במצרים? חפש אותי במוצש בבוקר." + "\n" + "כשתחליט להיות רציני תמצא אותי על ידי לחיצה על R"; 
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
            textdisplay.text = "<u> הנחשה דאס:  </u> שלום ברוכים הבאים למאפייה שלי, התכבדו ותרגישו בנוח באוהלי הקט?" + "\n" + "                        א. לעזור לי במשימה - יש ללחוץ על A" + "\n" + "                        ב. לקנות משהו - יש ללחוץ על B" + "\n" + "                        ג. לבקש רמז - יש ללחוץ על C" + "\n" + "                        ד. להסתובב מסביב - יש ללחוץ על D";
            return transform.position;
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
