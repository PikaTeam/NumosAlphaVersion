using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementAtPlusShop : MonoBehaviour
{
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

    private void Start()
    {
        textdisplay.text = "<u> הרוכל הנוכל:  </u> אני מתנצל אך תפסת אותנו באמצע שיפוצים, כמו שאתה רואה סופת חול פקדה את המקום ואנחנו כרגע מסדרים אותו, אשמח אם תשוב לבקר אותנו בהמשך, על מנת לצאת מהחנות יש לפנות שמאלה עד הסוף.";
    }



    // Update is called once per frame
    void Update()
    {
        transform.position = NewPosition();
    }
}
