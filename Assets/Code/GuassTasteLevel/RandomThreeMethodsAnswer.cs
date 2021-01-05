using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//this class genertas 3 maltipals numbers (2 same primes and one diffrent)
public class RandomThreeMethodsAnswer : MonoBehaviour
{
    //ints for primes
    int firstPrime;
    int SecondPrime;
    int combinationprime;

    //the chosen number
    int NumForDivide;

    //list of primes numbers
    int [] availableNumbers = {2, 3, 5, 7, 11};

    //for use text in screen
    public TextMeshProUGUI textdisplay;
    //textdisplay[index].text = num.ToString();

    //Bricknumber TextBoxs
    public TextMeshProUGUI[] BricksNumbersDisplay;

    //brick Objects
    public GameObject[] BricksPackage;

    //BricksPosition
    public List<Vector3> BricksOriginPosition = new List<Vector3>();

    //check if currect brick
    public GameObject checkbrick;

    //currectlevel
    public int level = 0;
    int basis = 0;
    int alredyhavebrickfirst = 0;
    int alredygotsecond = 0;
    bool alredygotbricksecond = false;
    bool alredycombinationprime = false;
    bool alredyfindfirst = false;
    bool alredydivisor = false;

    //showmassage
    public TextMeshProUGUI textdisplayshow;

    //gerete prime number
    void Start()
    {
        textdisplayshow.text = " אוי כמה בלאגן, קצה קשה להרכיב טאבון מלבנים כשאתותם להרים לא מצליחים. אשמח אם תוכלו בבקשה להניח שלוש לבנים המייצגות את המספרים מהם מורכבת כפולת המספר העליון בשטח האפור. " + "\n" + " לצורך הרמת הלבנים עליכם לעמוד ליד לבנה וללחוץ על המקש T." + "\n" + "על מנת להוריד לבנה עליכם ללחוץ על המקש G.";



        for (int i=0;i<BricksNumbersDisplay.Length;i++)
        {
            BricksOriginPosition.Add(BricksNumbersDisplay[i].transform.parent.parent.transform.position);
        }
        
        firstPrime = availableNumbers[randomindex()];
        Debug.Log("the first num is: " + firstPrime);
        SecondPrime = availableNumbers[randomindex()];
        Debug.Log("the second num is: " + SecondPrime);
        while (SecondPrime==firstPrime)
        {
            SecondPrime = availableNumbers[randomindex()];
        }

        NumForDivide = firstPrime * firstPrime * SecondPrime;
        Debug.Log("if the nums was same so this is the real one - the second num is: " + SecondPrime);
        textdisplay.text = NumForDivide.ToString();

        firstLevel();

    }

    //in the first level the charcther need to combine in one way the combination to divisornum
    //for this it have to find the nums that build it, so in first he have to find the right primes and put it on base;
    //second it have to find the right combinenum and the anoter prime
    //third floor is to put the divisornum;
    public void firstLevel()
    {
        combinationprime = firstPrime * firstPrime;
        BricksNumbersDisplay[0].text = firstPrime.ToString();
        Debug.Log("first num for first base: " + firstPrime);
        BricksNumbersDisplay[1].text = firstPrime.ToString();
        Debug.Log("seomd num for first base: " + firstPrime);
        BricksNumbersDisplay[2].text = SecondPrime.ToString();
        Debug.Log("thirs num for first base: " + SecondPrime);
        BricksNumbersDisplay[3].text = combinationprime.ToString();
        Debug.Log("first num for first base: " + combinationprime);
        BricksNumbersDisplay[4].text = SecondPrime.ToString();
        Debug.Log("thirs num for first base: " + SecondPrime);
        BricksNumbersDisplay[5].text = NumForDivide.ToString();

        for (int i = 6; i < BricksNumbersDisplay.Length; i++)
        {
            BricksNumbersDisplay[i].text = randomnums().ToString();
        }

        firstBase();



        




    }

    public bool firstBase()
    {
        level = 1;
        basis = 1;
        bool ok = false;

        if (alredygotbricksecond == true && alredyhavebrickfirst == 2)
        {
            textdisplayshow.text = "כל הכבוד! עכשיו תביאו לי עוד דרך שבאמצעותה אפשר לייצג את המספר הראשי של הפירמידה, איזה כפולת יתאימו?";
            Debug.Log("line 97");
            ok = true;

            level = 1;
            basis = 2;

            for (int i=0;i<BricksPackage.Length;i++)
            {
                BricksPackage[i].transform.position = BricksOriginPosition[i];
            }

            alredyhavebrickfirst = 0;
            alredygotbricksecond = false;

            secondbase();

        }
        return ok;
    }


    public bool secondbase()
    {
        bool ok = false;
        Debug.Log("im here 140" + alredygotbricksecond + "    " + alredycombinationprime);
        if (alredycombinationprime == true && alredygotbricksecond == true)
        {
            textdisplayshow.text = "כל הכבוד! עכשיו תביאו לי את הלבנה שהיא הלבנה המקורית?";
            Debug.Log("line 141");
            ok = true;

            level = 1;
            basis = 3;

            for (int i = 0; i < BricksPackage.Length; i++)
            {
                BricksPackage[i].transform.position = BricksOriginPosition[i];
            }




        }
        return ok;
    }

    public bool thirdbase()
    {
        bool ok = false;
        Debug.Log("im here 140" + alredygotbricksecond + "    " + alredycombinationprime);
        if (alredycombinationprime == true)
        {
            textdisplayshow.text = "כל הכבוד לכם! עכשיו בואו נראה האם תצליחו למצוא שילובים נוספים להרכבת הטאבון כי אני צריכה שתיים";
            Debug.Log("line 169");
            ok = true;

            level = 2;
            basis = 1;

            for (int i = 0; i < BricksPackage.Length; i++)
            {
                BricksPackage[i].transform.position = BricksOriginPosition[i];
            }

            bool alredycombinationprime = false;
            SecondLevel();



        }
        return ok;
    }



    //in the second level the charcther need to combine in anoter way the combination to divisornum
    //for this it have to find the nums that build it, so in first he have to find the right primes and put it on base;
    //second it have to find the right combinenum and the anoter prime
    //third floor is to put the divisornum;
    public void SecondLevel()
    {
        combinationprime = SecondPrime * SecondPrime;
        BricksNumbersDisplay[0].text = SecondPrime.ToString();
        Debug.Log("SecondPrime num for first base: " + firstPrime);
        BricksNumbersDisplay[1].text = firstPrime.ToString();
        Debug.Log("firstPrime num for first base: " + firstPrime);
        BricksNumbersDisplay[2].text = SecondPrime.ToString();
        Debug.Log("SecondPrime num for first base: " + SecondPrime);
        BricksNumbersDisplay[3].text = combinationprime.ToString();
        Debug.Log("combinationprime for first base: " + combinationprime);
        BricksNumbersDisplay[4].text = firstPrime.ToString();
        Debug.Log("firstPrime for first base: " + SecondPrime);
        BricksNumbersDisplay[5].text = NumForDivide.ToString();

        for (int i = 6; i < BricksNumbersDisplay.Length; i++)
        {
            BricksNumbersDisplay[i].text = randomnums().ToString();
        }

        Level2firstBase();

         alredyhavebrickfirst = 0;
         alredygotsecond = 0;
         alredygotbricksecond = false;
         alredycombinationprime = false;
         alredyfindfirst = false;
         alredydivisor = false;

        Debug.Log("i like water");










    }

    public bool Level2firstBase()
    {
        level = 2;
        basis = 1;
        bool ok = false;
        textdisplayshow.text = "מצוין, עכשיו אם תוכלו בבקשה להרכיב לי מגדל נוסף המורכב משלושה חלקים המרכיבים את הכפולה הנמצאת בראש המגדל??";

        if (alredygotbricksecond == true && alredyhavebrickfirst == 2)
        {
            textdisplayshow.text = "כל הכבוד, עכשיו איך עוד אתם יכולים לבנות מגדל משתי לבנים המרכיבות את הכפולה המופיעה מעל??";
            Debug.Log("line 229");
            ok = true;

            level = 2;
            basis = 2;

            for (int i = 0; i < BricksPackage.Length; i++)
            {
                BricksPackage[i].transform.position = BricksOriginPosition[i];
            }

             alredyhavebrickfirst = 0;
             alredygotsecond = 0;
             alredygotbricksecond = false;
             alredycombinationprime = false;
             alredyfindfirst = false;
             alredydivisor = false;

            Level2secondbase();

        }
        return ok;
    }


    public bool Level2secondbase()
    {
        bool ok = false;
        Debug.Log("im here 253" + alredygotbricksecond + "    " + alredycombinationprime);
        if (alredycombinationprime == true && alredygotbricksecond == true)
        {
            textdisplayshow.text = "כל הכבוד! אנא שימו בראש הטאבון את הלבנה הראשית שהיא הלבנה המורכבת מהכפולות?";
            Debug.Log("line 257");
            ok = true;

            level = 2;
            basis = 3;

            for (int i = 0; i < BricksPackage.Length; i++)
            {
                BricksPackage[i].transform.position = BricksOriginPosition[i];
            }
             alredyhavebrickfirst = 0;
             alredygotsecond = 0;
             alredygotbricksecond = false;
             alredycombinationprime = false;
             alredyfindfirst = false;
             alredydivisor = false;

            Level2thirdbase();



        }
        return ok;
    }

    public bool Level2thirdbase()
    {
        bool ok = false;
        Debug.Log("im here 278" + alredygotbricksecond + "    " + alredycombinationprime);
        if (alredycombinationprime == true)
        {
            textdisplayshow.text = "כל הכבוד לכם! עכשיו נזכרתי פתאום שאני צריכה עוד טאבון אחד אחרון, תוכלו בבקשה לעזור לי?";
            Debug.Log("line 282");
            ok = true;

            level = 3;
            basis = 1;

            for (int i = 0; i < BricksPackage.Length; i++)
            {
                BricksPackage[i].transform.position = BricksOriginPosition[i];
            }




        }
        return ok;
    }









    //in the third level the charcther need to combine in it way the combination to divisornum
    //for this it have to find the nums that build it, so in first he have to find the right primes and put it on base;
    //second it have to find the right combinenum and the anoter prime
    //third floor is to put the divisornum;
    public void thirdlevel(int num)
    {
        int combinationprime = SecondPrime * firstPrime;

    }

    public int randomindex()
    {
        int num = 0;
        int max = availableNumbers.Length;
        int min = 0;

        //genrete prime numer
        num = UnityEngine.Random.Range(min, max);
        return num;
    }

    public int randomnums()
    {
        int num = 0;
        int max = 23;
        int min = 12;

        //genrete prime numer
        num = UnityEngine.Random.Range(min, max);
        return num;
    }

    public bool checkifcurrect(GameObject brick, int level)
    {
        bool currect = false;
        if (level == 1)
        {
            if (basis == 1)
            {
                Debug.Log("im here 382");

                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == firstPrime && alredyhavebrickfirst < 2)
                {
                    alredyhavebrickfirst++;
                    textdisplayshow.text = "כל הכבוד בקרוב תהיו קרובים לסיים להרכיב את הטאבון, אתם מתקדמים";
                    currect = true;
                }
                else if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == SecondPrime && alredygotbricksecond == false)
                {
                    alredygotbricksecond = true;
                    currect = true;
                    textdisplayshow.text = "כל הכבוד מצאתם את המספר הראשוני השני במשוואה, כעת נשאר לכם למצוא את האיבר הראשון";
                }
                else if (brick.GetComponent<NumberAtBrick>().NumAtBrick() != SecondPrime || brick.GetComponent<NumberAtBrick>().NumAtBrick() != firstPrime)
                {
                    textdisplayshow.text = "חוששני שהבאתם לבנה שלא קשורה למשוואה, נסו שנית";
  
                }
               
            }

            if (basis == 2)
            {
                Debug.Log("im here 407");

                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == combinationprime && alredycombinationprime == false)
                {
                    alredycombinationprime = true;
                    textdisplayshow.text = "מצוין, כעת במה תכפלו את הלבנה שמצאתם על מנת לקבל את הערך של ראש הפירמידה?";
                    currect = true;
                }
                else if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == SecondPrime && alredygotbricksecond == false)
                {
                    alredygotbricksecond = true;
                    textdisplayshow.text = "מעולה עכשיו נשאר לכם רק למצוא לבנה שמתארת את כפולת שני האיברים החסרים";
                    currect = true;
                }
                else if (brick.GetComponent<NumberAtBrick>().NumAtBrick() != SecondPrime || brick.GetComponent<NumberAtBrick>().NumAtBrick() != combinationprime)
                {
                    textdisplayshow.text = "הלבנה שהבאתם לא מבינה, אנא נסו שוב";

                }

            }

            if (basis == 3)
            {
                Debug.Log("im here 431");

                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == NumForDivide)
                {
                    currect = true;
                     alredyhavebrickfirst = 0;
                     alredygotsecond = 0;
                     alredygotbricksecond = false;
                    
                     alredyfindfirst = false;
                     alredydivisor = false;
                     textdisplayshow.text = "כל הכבוד!";
                }

                else if (brick.GetComponent<NumberAtBrick>().NumAtBrick() != NumForDivide)
                {
                    textdisplayshow.text = "הייתם קרובים אבל זו לא הלבנה המתאימה";

                }
            }

        }

        if (level == 2)
        {
            if (basis == 1)
            {

                Debug.Log("im here 459");
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == firstPrime && alredyfindfirst == false)
                {
                    alredyhavebrickfirst++;
                    alredycombinationprime = false;
                    currect = true;
                    textdisplayshow.text = "מעולה הנחתם לבנה נכונה והיא הלבנה: " + firstPrime;
                }
                else if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == SecondPrime && alredygotsecond < 2)
                {
                    alredygotbricksecond = true;
                    currect = true;
                    textdisplayshow.text = "מעולה הנחתם לבנה  נכונה והיא הלבנה: " + SecondPrime;
                }

            }

            if (basis == 2)
            {
                Debug.Log("im here 477");

                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == combinationprime && alredycombinationprime == false)
                {
                    alredycombinationprime = true;
                    currect = true;
                    textdisplayshow.text = "מעולה הנחתם לבנה  נכונה והיא הלבנה: " + combinationprime;
                }
                else if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == firstPrime && alredyfindfirst == false)
                {
                    alredygotbricksecond = true;
                    currect = true;
                    textdisplayshow.text = "מעולה הנחתם לבנה  נכונה והיא הלבנה: " + firstPrime;
                }

            }

            if (basis == 3)
            {
                Debug.Log("im here 497");

                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == NumForDivide)
                {
                    currect = true;
                    textdisplayshow.text = "מעולה הנחתם לבנה נכונה והיא הלבנה: " + NumForDivide;
                }
            }
        }


        else return currect;

        return currect;



}

}
