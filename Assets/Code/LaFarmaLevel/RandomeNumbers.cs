using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomeNumbers : MonoBehaviour
{
    public TextMeshProUGUI [] textdisplay;
   

    //check if need random
    bool randomize;

    //list of all numbers
    public List<int> availableNumbers = new List<int>();
    public int size=0;

    //Bricknumber TextBoxs
    //public TextMeshProUGUI[] TailorStuffNumbersDisplay;

    //TailorStuff positions for later
    //Tailorstuff Objects
    public GameObject[] TailorPackage;

    //TailorStuffPositon
    public List<Vector3> StuffOriginPosition = new List<Vector3>();


    //check what is the level of the player
    bool hard = false;

    //show progress to player
    public TextMeshProUGUI textdisplayshow;

    //checkers in levels
    public int level = 0;
    bool done = false;
    int TheSmallest = 0;

    //zero container
   // public TextMeshProUGUI DisplayZero;
    //public GameObject ZeroRoll;


    // Start is called before the first frame update
    void Start()
    {
        textdisplayshow.text = "הגמלים שלי יובישבילי וחימול שוב בילגאנו לי את כל המתפרה, אשמח אם תוכלו בבקשה לעזור לי למצוא את הבדים המתאימים להכנת בגדי המלך החדשים" + "\n" + "לצורך לקיחת בד, עליכם לעמוד ליד הרול או הגליל הרצוי וללחוץ על המקש T." + "\n" + "על מנת להביא לי את הבד, עליכם להגיע אלי וללחוץ לידי על המקש G." + "\n" + "אנא מכם תמצאו את החלק עם הערך הקטן ביותר והביאו אותו אלי.";
        int small=0;
        int smallindex;
        Vector3 smallpos;
        if (availableNumbers.Count==0)
        {
            for (int i = 0; i < size; i++)
            {
                firstrandomizer(i, hard);
            }
        }
        else
        {
            for (int i = 0; i < availableNumbers.Count; i++)
            {
                randomizer(i, hard);
            }
        }

        for (int i = 0; i < textdisplay.Length; i++)
        {
            StuffOriginPosition.Add(textdisplay[i].transform.parent.parent.transform.position);
        }



        SavePos();

        small = smallest();
        TheSmallest = small;
        Debug.Log("the smalles is: " + small);
        smallindex = availableNumbers.IndexOf(small);
        Debug.Log("the index is: "+smallindex);
        smallpos = positon(smallindex);
        Debug.Log("the pos is: "+ smallpos);

        level = 1;
        FirstLevel();


    }

    public bool FirstLevel ()
    {
        level = 1;
        int small = 0;
        int smallindex;
        Vector3 smallpos;
        bool ok = false;

        if (done == true)
        {
            textdisplayshow.text = "כל הכבוד! עכשיו תוכלו בבקשה להביא לי עוד פעם את החפץ עם הערך הקטן ביותר?";
            Debug.Log("line 97");
            ok = true;

            level = 2;

            for (int i = 0; i < TailorPackage.Length; i++)
            {
                TailorPackage[i].transform.position = StuffOriginPosition[i];
            }
            done = false;

            for (int i = 1; i < availableNumbers.Count; i++)
            {
                randomizer(i, hard);
            }

            availableNumbers[0] = 0;
            textdisplay[0].text = 0.ToString();

            for (int i = 0; i < textdisplay.Length; i++)
            {
                StuffOriginPosition.Add(textdisplay[i].transform.parent.parent.transform.position);
            }

            SavePos();

            small = smallest();
            TheSmallest = small;
            Debug.Log("the smalles is: " + small);
            smallindex = availableNumbers.IndexOf(small);
            Debug.Log("the index is: " + smallindex);
            smallpos = positon(smallindex);
            Debug.Log("the pos is: " + smallpos);

            SecondLevel();
        }
    
        return ok;
    }

    public bool SecondLevel()
    {
        //level = 2;
        bool ok = false;

        if (done == true)
        {
            int small = 0;
            int smallindex;
            Vector3 smallpos;
            textdisplayshow.text = "איזה התקדמות מרשימה! נשאר רק עוד חפץ אחד ברשימה, תוכלו בבקשה להביא לי שוב את החפץ הקטן ביותר על המדפים?";
            Debug.Log("line 151");
            ok = true;
            hard = true;

            level = 3;

            availableNumbers[0] = UnityEngine.Random.Range(1, 12);
            textdisplay[0].text = availableNumbers[0].ToString();


            for (int i = 0; i < TailorPackage.Length; i++)
            {
                TailorPackage[i].transform.position = StuffOriginPosition[i];
            }
            done = false;

            for (int i = 1; i < availableNumbers.Count; i++)
            {
                randomizer(i, hard);
            }

            //availableNumbers[0] = 0;
            //textdisplay[0].text = 0.ToString();

            for (int i = 0; i < textdisplay.Length; i++)
            {
                StuffOriginPosition.Add(textdisplay[i].transform.parent.parent.transform.position);
            }

            SavePos();

            small = smallest();
            TheSmallest = small;
            Debug.Log("the smalles is: " + small);
            smallindex = availableNumbers.IndexOf(small);
            Debug.Log("the index is: " + smallindex);
            smallpos = positon(smallindex);
            Debug.Log("the pos is: " + smallpos);

            SecondLevel();

        }
        return ok;
    }

    public bool thirdLevel()
    {
        level = 3;
        bool ok = false;

        if (done == true)
        {
            textdisplayshow.text = "אתם פשוט מוכשרים! הצלחתם להביא לי את כל הרכיבים הדרושים, עכשיו אוכל להכין עבורכם את אחד החלקים שאתם צריכים למען הצלת המלך" + "\n" + "שיטת בחירת האיבר הנמוך ביותר שבה השתמשתם בחנות שלי מכונה שיטת ה- WOP שמכונה 'עיקרון הסדר הטוב' - פירושו שבכל קבוצה של מספרים בקבוצה אפשר למצוא בהכרח מספר שהוא הקטן ביותר מכל האיברים.";
            Debug.Log("line 207");
            SingleToon.getInstance().curmoney.gain(50);
            SingleToon.getInstance().curscore.raise(150);
            ok = true;

            for (int i = 0; i < TailorPackage.Length; i++)
            {
                TailorPackage[i].transform.position = StuffOriginPosition[i];
            }

        }
        return ok;
    }

    public bool checkifcurrect(GameObject TailorCurrectStuff)
    {
        bool currect = false;
        if (level == 1)
        {
                if (TailorCurrectStuff.GetComponent<NumberAtBrick>().NumAtBrick() == TheSmallest)
                {
                    currect = true;
                    done = true;
                    Debug.Log("line 117 its done great");
                }

                else if (TailorCurrectStuff.GetComponent<NumberAtBrick>().NumAtBrick() != TheSmallest)
                 {
                  textdisplayshow.text = "מצטער אבל אני רואה בזווית העין חפץ עם ערך קטן יותר מזה שהבאתם לי" + "\n" + "נסו שנית בבקשה";
                 }
        }

        if (level == 2)
        {
            Debug.Log("im in level 2");
            if (TailorCurrectStuff.GetComponent<NumberAtBrick>().NumAtBrick() == TheSmallest)
            {
                currect = true;
                done = true;
                Debug.Log("line 181 its done great");
            }
            else if (TailorCurrectStuff.GetComponent<NumberAtBrick>().NumAtBrick() == 0)
            {
                textdisplayshow.text = "רואים שאתם לא מקומיים, אצלנו בממלכת הטבעיים המספר 0 לא שייך לקבוצה, הרי לא יכול להיות מצב שחפץ יהיה אפסי נכון? הרי הוא קיים ויש לו משקל מסוים לא חושבים? " + "\n" + "תנסו שוב בבקשה.";
            }
            else if (TailorCurrectStuff.GetComponent<NumberAtBrick>().NumAtBrick() != TheSmallest)
            {
                textdisplayshow.text = "מצטער אבל אני רואה בזווית העין חפץ עם ערך קטן יותר מזה שהבאתם לי" + "\n" + "נסו שנית בבקשה";
            }

        }

        if (level == 3)
        {
            Debug.Log("im in level 3");
            if (TailorCurrectStuff.GetComponent<NumberAtBrick>().NumAtBrick() == TheSmallest)
            {
                currect = true;
                done = true;
                Debug.Log("line 181 its done great");
            }
            else if (TailorCurrectStuff.GetComponent<NumberAtBrick>().NumAtBrick() == 0)
            {
                textdisplayshow.text = "רואים שאתם לא מקומיים, אצלנו בממלכת הטבעיים המספר 0 לא שייך לקבוצה, הרי לא יכול להיות מצב שחפץ יהיה אפסי נכון? הרי הוא קיים ויש לו משקל מסוים לא חושבים? " + "\n" + "תנסו שוב בבקשה.";
            }
            else if (TailorCurrectStuff.GetComponent<NumberAtBrick>().NumAtBrick() < 0)
            {
                textdisplayshow.text = "כמו שכבר ציינתי אתם נמצאים בממלכת הטבעיים, אצלנו את השליליים לצינוק זורקים ובטח שאין לנו פריטים שלילים, אנחנו נמצאים תמיד מעל ה-0. " + "\n" + "תנסו שוב בבקשה.";
            }

            else if (TailorCurrectStuff.GetComponent<NumberAtBrick>().NumAtBrick() != TheSmallest)
            {
                textdisplayshow.text = "מצטער אבל אני רואה בזווית העין חפץ עם ערך קטן יותר מזה שהבאתם לי" + "\n" + "נסו שנית בבקשה";
            }
        }

        return currect;
    }



       public void SavePos ()
        {
        for (int i = 0; i < textdisplay.Length; i++)
        {
            TailorPackage[i].transform.position = StuffOriginPosition[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void randomizer (int index, bool hard)
    {
        int num = 0;
        int max = 200;
        int maxhard = 10;
        int min = 1;
        int underzero = -30;

        if (hard == true)
        {
            num = UnityEngine.Random.Range(underzero, maxhard);
            if (availableNumbers.Contains(num))
            {
                randomizer(index, hard);
            }
            else
            {
                availableNumbers[index] = num;
                textdisplay[index].text = num.ToString();
            }
        }

        else
        {
            num = UnityEngine.Random.Range(min, max);
            if (availableNumbers.Contains(num))
            {
                randomizer(index, hard);
            }
            else
            {
                availableNumbers[index] = num;
                textdisplay[index].text = num.ToString();
            }
        }

 

    }

    public void firstrandomizer(int index, bool hard)
    {
        int num = 0;
        int max = 200;
        int min = 1;

            num = UnityEngine.Random.Range(min, max);
           if (availableNumbers.Contains(num))
            {
                firstrandomizer(index, hard);
            }
            else
            {
            availableNumbers.Add(num);
            textdisplay[index].text = num.ToString();
            }
        
    }

    public Vector3 positon (int index)
    {
        Vector3 mypos;
        mypos = textdisplay[index].transform.position;
        return mypos;
    }

    public int smallest ()
    {
        int min = availableNumbers[0];
        if (min==0)
        {
            min = availableNumbers[1];
        }

        for (int i = 0; i < size; i++)
        {
            if (availableNumbers[i] < min && availableNumbers[i] != 0 && availableNumbers[i] > 0)
            {
                min = availableNumbers[i];
            }
        }

 
        return min;
    }


    }
