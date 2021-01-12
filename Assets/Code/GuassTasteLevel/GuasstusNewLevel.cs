using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuasstusNewLevel : MonoBehaviour
{    //ints for primes
    int firstPrime;
    int SecondPrime;
    int combinationprime;
    int combinationprime2;

    //the chosen number
    int NumForDivide;

    //list of primes numbers
    int[] availableNumbers = { 2, 3, 5, 7, 11 };

    //for use text in screen
    public TextMeshProUGUI textdisplay;
    //textdisplay[index].text = num.ToString();

    //Bricknumber TextBoxs
    public TextMeshProUGUI[] BricksNumbersDisplay;
    public TextMeshProUGUI[] DoneMissiobBrickDisplay;
    public TextMeshProUGUI[] DoneMissiobBrickDisplay2;
    public int DoneMissBobrickSize;
    //brick Objects
    public GameObject[] BricksPackage;
    

    //BricksPosition
    public List<Vector3> BricksOriginPosition = new List<Vector3>();

    //check if currect brick
    public GameObject checkbrick;

    //currectlevel
    public int level = 0;
    public int basis = 0;
    public bool done = false; //check if the mission acomplish
    public int count;
    public int count2;

    //showmassage ,explain things to the player while he plays
    public TextMeshProUGUI textdisplayshow;

    //Levels Checkers
    int FirstPrimeGot = 0;
    int SecondPrimeGot = 0;
    bool combinationGot = false;
    bool NumForDivisGot = false;

    //method to put diffrent prime numbers into bricks
    public int randomindex()
    {
        int num = 0;
        int max = availableNumbers.Length;
        int min = 0;

        //genrete prime numer
        num = UnityEngine.Random.Range(min, max);
        return num;
    }

    //method that find random numers to put into bricks
    public int randomnums()
    {
        int num = 0;
        int max = 23;
        int min = 12;

        //genrete prime numer
        num = UnityEngine.Random.Range(min, max);
        return num;
    }

    void Start()
    {
        count = DoneMissiobBrickDisplay.Length - 1;
        //the first instruction text display
        textdisplayshow.text = " אוי כמה בלאגן, קצה קשה להרכיב טאבון מלבנים כשאותם להרים לא מצליחים. אשמח אם תוכלו בבקשה למצוא לבנה עם אותו ערך כמו הלבנה האפורה שלידי ולהניח על ראש המגדל , שימו לב שאת הלבנה האפורה אי אפשר להרים אז תמצאו ערך דומה לה בחלקת הלבנים החומות?. " + "\n" + " לצורך הרמת הלבנים עליכם לעמוד ליד לבנה וללחוץ על המקש T." + "\n" + "על מנת להוריד לבנה עליכם ללחוץ על המקש G.";

        //save the posions of my bricks (will need it later to put them back to hair origin positon
        for (int i = 0; i < BricksNumbersDisplay.Length; i++)
        {
            BricksOriginPosition.Add(BricksNumbersDisplay[i].transform.parent.parent.transform.position);
        }

        //find the first prime number
        firstPrime = availableNumbers[randomindex()];
        Debug.Log("The First Prime is: " + firstPrime);
        SecondPrime = availableNumbers[randomindex()];

        while (SecondPrime == firstPrime)
        {
            SecondPrime = availableNumbers[randomindex()];
        }
        Debug.Log("The Second prime is: " + SecondPrime);

        //tabon number that made from the primes
        NumForDivide = firstPrime * firstPrime * SecondPrime;
        textdisplay.text = NumForDivide.ToString();

        FirstLevel();

    }

    //in the first level they need to find find three importent things
    // A. the prime numbers that made the diviosor = three values
    // B. the first prime *first prime combintion and the second prime = two values
    // c. the diviosor
    public void FirstLevel()
    {
        //put values into bricks
        combinationprime = firstPrime * firstPrime;
        BricksNumbersDisplay[0].text = firstPrime.ToString();
        Debug.Log("Base1 Number: " + firstPrime);
        BricksNumbersDisplay[1].text = firstPrime.ToString();
        Debug.Log("Base1 Number2: " + firstPrime);
        BricksNumbersDisplay[2].text = SecondPrime.ToString();
        Debug.Log("Base1 Number3: " + SecondPrime);
        BricksNumbersDisplay[3].text = combinationprime.ToString();
        Debug.Log("Base2 Number1: " + combinationprime);
        BricksNumbersDisplay[4].text = SecondPrime.ToString();
        Debug.Log("Base2 Number2: " + SecondPrime);
        BricksNumbersDisplay[5].text = NumForDivide.ToString();

        // put random values into the ohter bricks
        for (int i = 6; i < BricksNumbersDisplay.Length; i++)
        {
            BricksNumbersDisplay[i].text = randomnums().ToString();
        }

        level = 1;
        basis = 3;
        ThirdBase();
    }

    public bool FirstBase()
    {
        //check if the base is done
        bool ok = false;
        Debug.Log("the second prime checker vaalue is: " + SecondPrimeGot + " and the first prim calue is: " + FirstPrimeGot);
        if (SecondPrimeGot == 1 && FirstPrimeGot == 2 && level ==1)
        {
            //reset checkers
            FirstPrimeGot = 0;
            SecondPrimeGot = 0;
            combinationGot = false;
            NumForDivisGot = false;

            //let the player know his status
            textdisplayshow.text = "כל הכבוד, כעת כמו שאתם רואים יש לי שתי  פירמידות , אשמח אם תוכלו בבקשה לעזור לי ולהרכיב עוד טאבון אחד, לצורך כך יש בתור התחלה להביא לי את הלבנה שערכה שווה לערך של הלבנה האפורה שלידי?";
            Debug.Log("line 143 - level1 - finish first base");

            //set ok - that the mission is done
            ok = true;

            //set new level and basis
            level = 2;
            basis = 3;

            //put back the bricks into thir origan position
            for (int i = 0; i < BricksPackage.Length; i++)
            {
                BricksPackage[i].transform.position = BricksOriginPosition[i];
            }

            SecondLevel();


            return ok;
        }

        if (SecondPrimeGot == 1 && FirstPrimeGot == 2 && level == 2)
        {
            //reset checkers
            FirstPrimeGot = 0;
            SecondPrimeGot = 0;
            combinationGot = false;
            NumForDivisGot = false;

            //let the player know his status
            textdisplayshow.text = "כל הכבוד!!! עכשיו אני אוכל להכין יותר מטעמים וכמובן להשלים להכנת את החלק הדרוש להצלת המלך. אופן הפעולה שלכם בשיטה היה לפי מספרים פריקים, האומר שכל מספר פריק מורכב מכפל של מספרים ראשוניים" + "\n" + "נזכור שמספר פריק פירושו מספר שהוא לא ראשוני, מספר ראשוני זה מספר שמתחלק רק באחד ובעצמו." + "\n" + "בתודה על העזרה הרבה שלכם קבלו פרס קטן זה ותחזרו לחפש בממלכה את שאר הרכיבים הדרושים";
            Debug.Log("line 255 - level2 - base3 - done");

            //set ok - that the mission is done
            ok = true;

            //set new level and basis
            //level = 2;
            basis = 1;

            //put the bricks back
            for (int i = 0; i < BricksPackage.Length; i++)
            {
                BricksPackage[i].transform.position = BricksOriginPosition[i];
            }

            SingleToon.getInstance().curmoney.gain(100);
            SingleToon.getInstance().curscore.raise(300);

            //SecondBase();
            return ok;

        }
        return ok;
    }

    public bool SecondBase()
    {
        //check if the base have been done
        bool ok = false;
        Debug.Log("im here 168" + SecondPrimeGot + "    " + combinationGot);
        if (combinationGot == true && SecondPrimeGot == 1 && level == 1)
        {
            //reset checkers
            FirstPrimeGot = 0;
            SecondPrimeGot = 0;
            combinationGot = false;
            NumForDivisGot = false;

            //let the player know his status
            textdisplayshow.text = "כל הכבוד! עכשיו, הביאו לי שלושה ערכים, שניים מהם שכפולה ביניהם מביאה לי את המספר הפריק )מספר המורכב מראשוניים( והשלישי מספר ראשוני שכפולה שלו בהם תניב לי את ערך הכפולה של הלבנה האפורה?";
            Debug.Log("line 172 - level1 - base2 - done");

            //set ok - that the mission is done
            ok = true;

            //set new level and basis
            //level = 1;
            basis = 1;

            //put the bricks into their origan places
            for (int i = 0; i < BricksPackage.Length; i++)
            {
                BricksPackage[i].transform.position = BricksOriginPosition[i];
            }

            FirstBase();

            return ok;

        }

        if (combinationGot == true && FirstPrimeGot == 1 && level == 2)
        {
            //reset checkers
            FirstPrimeGot = 0;
            SecondPrimeGot = 0;
            combinationGot = false;
            NumForDivisGot = false;

            //let the player know his status
            textdisplayshow.text = "כל הכבוד! עכשיו, הביאו לי שלושה ערכים, שניים מהם שכפולה ביניהם מביאה לי את המספר הפריק )מספר המורכב מראשוניים( והשלישי מספר ראשוני שכפולה שלו בהם תניב לי את ערך הכפולה של הלבנה האפורה?";
            Debug.Log("line 172 - level1 - base2 - done");

            //set ok - that the mission is done
            ok = true;

            //set new level and basis
            //level = 1;
            basis = 1;

            //put the bricks into their origan places
            for (int i = 0; i < BricksPackage.Length; i++)
            {
                BricksPackage[i].transform.position = BricksOriginPosition[i];
            }

            FirstBase();

            return ok;

        }
        return ok;

    }

    public bool ThirdBase()
    {
        bool ok = false;
        Debug.Log("im here 202" + NumForDivisGot);
        if (NumForDivisGot == true && level == 1)
        {
            //reset checkers
            FirstPrimeGot = 0;
            SecondPrimeGot = 0;
            combinationGot = false;
            NumForDivisGot = false;

            //let the player know his status
            textdisplayshow.text = "כל הכבוד! כעת הביאו לי שני ערכים שהכפולה שלהם שווה לערך הלבנה האפורה?";
            //textdisplayshow.text = "כל הכבוד לכם! עכשיו בואו נראה האם תצליחו למצוא שילובים נוספים להרכבת הטאבון כי אני צריכה שתיים" + "\n" + "כל שעליכם לעשות זה למצוא דרך נוספת להגיע למכפלה המופיעה למעל השונה מהדרך הראשונה שמצאתם, שימו לב שייתכן שהראשוניים ישארו אותם הראשוניים ורק סדר ההכפלה ישתנה";
            Debug.Log("line 207 - level1 - base3 - done");

            //set ok - that the mission is done
            ok = true;

            //set new level and basis
            //level = 2;
            basis = 2;

            //put the bricks back
            for (int i = 0; i < BricksPackage.Length; i++)
            {
                BricksPackage[i].transform.position = BricksOriginPosition[i];
            }

            SecondBase();
            return ok;

        }

        if (NumForDivisGot == true && level == 2)
        {
            //reset checkers
            FirstPrimeGot = 0;
            SecondPrimeGot = 0;
            combinationGot = false;
            NumForDivisGot = false;

            //let the player know his status
            //textdisplayshow.text = "כל הכבוד!!! עכשיו אני אוכל להכין יותר מטעמים וכמובן להשלים להכנת את החלק הדרוש להצלת המלל. אופן הפעולה שלכם בשיטה היה לפי מספרים פריקים, האומר שכל מספר פריק מורכב מכפל של מספרים ראשוניים" + "\n" + "נזכור שמספר פריק פירושו מספר שהוא לא ראשוני, מספר ראשוני זה מספר שמתחלק רק באחד ובעצמו." + "\n" + "בתודה על העזרה הרבה שלכם קבלו פרס קטן זה";
            Debug.Log("line 255 - level2 - base3 - done");

            //set ok - that the mission is done
            ok = true;

            //set new level and basis
            //level = 2;
            basis = 2;

            //put the bricks back
            for (int i = 0; i < BricksPackage.Length; i++)
            {
                BricksPackage[i].transform.position = BricksOriginPosition[i];
            }

            //SingleToon.getInstance().curmoney.gain(100);
            //SingleToon.getInstance().curscore.raise(300);

            SecondBase();
            return ok;

        }
        return ok;
    }


    public void SecondLevel()
    {
        count2 = DoneMissiobBrickDisplay2.Length - 1;
        level = 2;
        basis = 3;
        //put values into bricks
        combinationprime2 = SecondPrime * firstPrime;
        BricksNumbersDisplay[0].text = SecondPrime.ToString();
        Debug.Log("Base1 Number: " + SecondPrime);
        BricksNumbersDisplay[1].text = firstPrime.ToString();
        Debug.Log("Base1 Number2: " + firstPrime);
        BricksNumbersDisplay[2].text = firstPrime.ToString();
        Debug.Log("Base1 Number3: " + firstPrime);
        BricksNumbersDisplay[3].text = combinationprime2.ToString();
        Debug.Log("Base2 Number1: " + combinationprime2);
        BricksNumbersDisplay[4].text = firstPrime.ToString();
        Debug.Log("Base2 Number2: " + firstPrime);
        BricksNumbersDisplay[5].text = NumForDivide.ToString();

        // put random values into the ohter bricks
        for (int i = 6; i < BricksNumbersDisplay.Length; i++)
        {
            BricksNumbersDisplay[i].text = randomnums().ToString();
        }

        //put the bricks back
        for (int i = 0; i < BricksPackage.Length; i++)
        {
            BricksPackage[i].transform.position = BricksOriginPosition[i];
        }

        level = 2;
        basis = 3;
        ThirdBase();
    }










    public bool CheckIfCorrect(GameObject brick, int level)
    {
        //check if the brick is currect
        bool currect = false;
        Debug.Log("im in CheckIfCorrect Func");

        //the level 1 check
        if (level == 1)
        {
            
            Debug.Log("level1 - now im in the level 1 checkers");
            if (basis == 1)
            {
                Debug.Log("level1 - base1 - i check if the first base is ok ");

                //check if we got to first prime bricks
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == firstPrime && FirstPrimeGot < 2)
                {
                    FirstPrimeGot++;
                    DoneMissiobBrickDisplay[count].text = firstPrime.ToString();
                    count--;
                    Debug.Log("level1 - base1 - you find" + firstPrime + " " + FirstPrimeGot + "bricks " );
                    textdisplayshow.text = " כל הכבוד, מצאת " + FirstPrimeGot + " מתוך 2, יש להשלים את החסר";
                    return true;
                }

                //check if we got the second prime brick
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == SecondPrime && SecondPrimeGot != 1)
                {
                    SecondPrimeGot++;
                    DoneMissiobBrickDisplay[count].text = SecondPrime.ToString();
                    count--;
                    Debug.Log("level1 - base1 - you find" + SecondPrime + " " + SecondPrimeGot + "bricks");
                    textdisplayshow.text = " מצוין, מצאת " + SecondPrimeGot + " מתוך 1, יש להשלים את המספר הראשוני השני";

                    return true;
                }

                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() != 2 || brick.GetComponent<NumberAtBrick>().NumAtBrick() != 3 || brick.GetComponent<NumberAtBrick>().NumAtBrick() != 5 || brick.GetComponent<NumberAtBrick>().NumAtBrick() != 7 || brick.GetComponent<NumberAtBrick>().NumAtBrick() != 11)
                {
                    Debug.Log("level1 - base1 - you find " + brick.GetComponent<NumberAtBrick>().NumAtBrick() + " not a prime");
                    textdisplayshow.text = " מצטערת, אני צריכה שהטאבון שלי יהיה מורכב ממספרים ראשונים, כאלה שאי אפשר לפרק לחלקים למספרים אחרים כמו מספרים פריקים, כמו שאתם וודאי זוכרים מספר פריק הוא מספר שמורכב ממספרים ראשוניים.";
                }

                //if the player didnt find the right brick
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() != SecondPrime && brick.GetComponent<NumberAtBrick>().NumAtBrick() != firstPrime)
                {
                    if (brick.GetComponent<NumberAtBrick>().NumAtBrick() != 2 || brick.GetComponent<NumberAtBrick>().NumAtBrick() != 3 || brick.GetComponent<NumberAtBrick>().NumAtBrick() != 5 || brick.GetComponent<NumberAtBrick>().NumAtBrick() != 7 || brick.GetComponent<NumberAtBrick>().NumAtBrick() != 11)
                    {
                        Debug.Log("level1 - base1 - you find " + brick.GetComponent<NumberAtBrick>().NumAtBrick() + " not a prime");
                        textdisplayshow.text = " מצטערת, אני צריכה שהטאבון שלי יהיה מורכב ממספרים ראשונים, כאלה שאי אפשר לפרק לחלקים למספרים אחרים כמו מספרים פריקים, כמו שאתם וודאי זוכרים מספר פריק הוא מספר שמורכב ממספרים ראשוניים.";
                    }
                    else
                    {
                        Debug.Log("level1 - base1 - you wrong");
                        textdisplayshow.text = "חוששני שהמספר הזה לא מייצג את הכפולה המצויינת בראש המגדל";
                        return true;
                    }

                }


            }


            ///////////////////////////////Basis 2/////////////////////////
            Debug.Log("level1 - now im in the level 2 - checkers");
            if (basis == 2)
            {
                Debug.Log("level1 - base2 - i check if the first base is ok ");

                //check if we got to first prime bricks
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == combinationprime && combinationGot == false)
                {
                    combinationGot = true;
                    DoneMissiobBrickDisplay[count].text = combinationprime.ToString();
                    count--;
                    Debug.Log("level1 - base2 - you find" + combinationprime);
                    textdisplayshow.text = " כל הכבוד, מצאת "  + " מתוך אחד, עכשיו, במה תכפיל אותו כדי לקבל את המספר שבראש הטאבון?";
                    return true;
                }

                //check if we got the second prime brick
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == SecondPrime && SecondPrimeGot != 1)
                {
                    SecondPrimeGot++;
                    Debug.Log("level1 - base2 - you find" + SecondPrime + " " + SecondPrimeGot + "bricks");
                    DoneMissiobBrickDisplay[count].text = SecondPrime.ToString();
                    count--;
                    textdisplayshow.text = " מצוין, מצאת " + SecondPrimeGot + "  מתוך אחד, עכשיו, באיזה כפולה תכפול אותו כדי לקבל את המספר שנמצא בראש הטאבון?";

                    return true;
                }

                //if the player didnt find the right brick
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() != SecondPrime && brick.GetComponent<NumberAtBrick>().NumAtBrick() != combinationprime)
                {
                    Debug.Log("level1 - base2 - you wrong");
                    textdisplayshow.text = "אני חוששת שהמספרים הללו לא מייצגים את הכפולה המצויינת בראש המגדל";
                    return true;
                }

                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() != 2 || brick.GetComponent<NumberAtBrick>().NumAtBrick() != 3 || brick.GetComponent<NumberAtBrick>().NumAtBrick() != 5 || brick.GetComponent<NumberAtBrick>().NumAtBrick() != 7 || brick.GetComponent<NumberAtBrick>().NumAtBrick() != 11)
                {
                    Debug.Log("level1 - base1 - you find " + brick.GetComponent<NumberAtBrick>().NumAtBrick() + " not a prime");
                    textdisplayshow.text = " מצטערת, אני צריכה שהטאבון שלי יהיה מורכב ממספרים ראשונים, כאלה שאי אפשר לפרק לחלקים למספרים אחרים כמו מספרים פריקים, כמו שאתם וודאי זוכרים מספר פריק הוא מספר שמורכב ממספרים ראשוניים.";
                }
            }


            ///////////////////Basis 3//////////////////////////////
            ///Debug.Log("level1 - now im in the level 2 - checkers");
            if (basis == 3)
            {
                Debug.Log("level1 - base3 - i check if ok ");

                //check if we got to first prime bricks
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == NumForDivide && NumForDivisGot == false)
                {
                    NumForDivisGot = true;
                    DoneMissiobBrickDisplay[count].text = NumForDivide.ToString();
                    count--;
                    Debug.Log("level1 - base3 - you find" + NumForDivide);
                    //textdisplayshow.text = " כל הכבוד, מצאת " + combinationprime + " עכשיו, במה תכפיל אותו כדי לקבל את המספר שבראש הטאבון?";
                    return true;
                }

                //if the player didnt find the right brick
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() != NumForDivide)
                {
                    Debug.Log("level1 - base3 - you wrong");
                    textdisplayshow.text = "אני חוששת שהמספרים הללו לא מייצגים את המספר שנמצא בראש הטאבון";
                    return true;
                }
            }


        }



        ///////////////////////LeveL 2 ////////////////////////////////////
        if (level == 2)
        {
            //int count = DoneMissiobBrickDisplay.Length;
            Debug.Log("level2 - now im in the base 1 checkers");
            if (basis == 1)
            {
                Debug.Log("level2 - base1 - i check if the first base is ok ");

                //check if we got to first prime bricks
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == firstPrime && FirstPrimeGot < 2)
                {
                    FirstPrimeGot++;
                    DoneMissiobBrickDisplay2[count2].text = firstPrime.ToString();
                    Debug.Log("level2 - base1 - you find" + firstPrime + " " + FirstPrimeGot + "bricks");
                    textdisplayshow.text = " איזה יופי, מצאת " + FirstPrimeGot + " מתוך שניים, יש להשלים את החסר";
                    count2--;
                    return true;
                }

                //check if we got the second prime brick
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == SecondPrime && SecondPrimeGot != 1)
                {
                    SecondPrimeGot++;
                    DoneMissiobBrickDisplay2[count2].text = SecondPrime.ToString();
                    count2--;
                    Debug.Log("level2 - base1 - you find" + SecondPrime + " " + SecondPrimeGot + "bricks");
                    textdisplayshow.text = " נהדר, מצאת " + SecondPrimeGot + " מתוך אחד, יש להשלים את המספר הראשוני השני";

                    return true;
                }

                //if the player didnt find the right brick
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() != SecondPrime && brick.GetComponent<NumberAtBrick>().NumAtBrick() != firstPrime)
                {
                    Debug.Log("level2 - base1 - you wrong");
                    textdisplayshow.text = "לצערי המספרים הללו לא מייצגים את הכפולה המצויינת בראש המגדל";
                    return true;
                }
            }


            ///////////////////////////////Basis 2/////////////////////////
            Debug.Log("level2 - now im in the level 2 - checkers");
            if (basis == 2)
            {
                Debug.Log("level2 - base2 - i check if the first base is ok ");

                //check if we got to first prime bricks
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == combinationprime2 && combinationGot == false)
                {
                    combinationGot = true;
                    DoneMissiobBrickDisplay2[count2].text = combinationprime2.ToString();
                    count2--;
                    Debug.Log("level2 - base2 - you find" + combinationprime2);
                    textdisplayshow.text = " נדיר, מצאת "  + " מתוך אחד, עכשיו, במה תכפיל אותו כדי לקבל את המספר שבראש הטאבון?";
                    return true;
                }

                //check if we got the second prime brick
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == firstPrime && SecondPrimeGot != 1)
                {
                    FirstPrimeGot++;//at 21.1.2021 it was second primegot
                    DoneMissiobBrickDisplay2[count2].text = firstPrime.ToString();
                    count2--;
                    Debug.Log("level2 - base2 - you find" + firstPrime + " " + FirstPrimeGot + "bricks");
                    textdisplayshow.text = " יופידו!, מצאת " + FirstPrimeGot + "  מתוך אחד, עכשיו, באיזה כפולה תכפול אותו כדי לקבל את המספר שנמצא בראש הטאבון?";

                    return true;
                }

                //if the player didnt find the right brick
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() != firstPrime && brick.GetComponent<NumberAtBrick>().NumAtBrick() != combinationprime)
                {
                    Debug.Log("level1 - base2 - you wrong");
                    textdisplayshow.text = "אוי,  חוששת שהמספרים הללו לא מייצגים את הכפולה המצויינת בראש המגדל";
                    return true;
                }
            }


            ///////////////////Basis 3//////////////////////////////
            ///Debug.Log("level1 - now im in the level 2 - checkers");
            if (basis == 3)
            {
                Debug.Log("level2 - base3 - i check if ok ");

                //check if we got to first prime bricks
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == NumForDivide && NumForDivisGot == false)
                {
                    NumForDivisGot = true;
                    DoneMissiobBrickDisplay2[count2].text = NumForDivide.ToString();
                    count2--;
                    Debug.Log("level2 - base3 - you find" + NumForDivide);
                    //textdisplayshow.text = " פשוט כישרון, מצאת " + combinationprime + " עכשיו, במה תכפיל אותו כדי לקבל את המספר שבראש הטאבון?";
                    return true;
                }

                //if the player didnt find the right brick
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() != NumForDivide)
                {
                    Debug.Log("level2 - base3 - you wrong");
                    textdisplayshow.text = "אני חוששת שהמספרים הללו לא מייצגים את המספר שנמצא בראש הטאבון";
                    return true;
                }
            }


        }
        return currect;
    }
}
