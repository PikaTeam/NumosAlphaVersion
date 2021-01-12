using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberSuffleForGuasstaste : MonoBehaviour
{
    //ints for primes
    int firstPrime;
    int SecondPrime;
    int combinationprime;

    //the chosen number
    int NumForDivide;

    //list of primes numbers
    int[] availableNumbers = { 2, 3, 5, 7, 11 };

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
    public int basis = 0;
    public bool done = false; //check if the mission acomplish

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
        //the first instruction text display
        textdisplayshow.text = " אוי כמה בלאגן, קצה קשה להרכיב טאבון מלבנים כשאתותם להרים לא מצליחים. אשמח אם תוכלו בבקשה להניח שלוש לבנים המייצגות את המספרים מהם מורכבת כפולת המספר העליון בשטח האפור. " + "\n" + " לצורך הרמת הלבנים עליכם לעמוד ליד לבנה וללחוץ על המקש T." + "\n" + "על מנת להוריד לבנה עליכם ללחוץ על המקש G.";

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
        basis = 1;
        FirstBase();
    }

    public bool FirstBase()
    {

        //check if the base is done
        bool ok = false;
        Debug.Log("the second prime checker vaalue is: " + SecondPrimeGot + " and the first prim calue is: " + FirstPrimeGot);
        if (SecondPrimeGot == 1 && FirstPrimeGot == 2)
        {
            //reset checkers
            FirstPrimeGot = 0;
            SecondPrimeGot = 0;
            combinationGot = false;
            NumForDivisGot = false;

            //let the player know his status
            textdisplayshow.text = "כל הכבוד! עכשיו תביאו לי עוד דרך שבאמצעותה אפשר לייצג את המספר הראשי של הפירמידה, איזה כפולת יתאימו?";
            Debug.Log("line 143 - level1 - finish first base");

            //set ok - that the mission is done
            ok = true;

            //set new level and basis
            //level = 1;
            basis = 2;

            //put back the bricks into thir origan position
            for (int i = 0; i < BricksPackage.Length; i++)
            {
                BricksPackage[i].transform.position = BricksOriginPosition[i];
            }

            SecondBase();


            return ok;
        }
        return ok;
    }

    public bool SecondBase()
    {
        //check if the base have been done
        bool ok = false;
        Debug.Log("im here 168" + SecondPrimeGot + "    " + combinationGot);
        if (combinationGot == true && SecondPrimeGot == 1)
        {
            //reset checkers
            FirstPrimeGot = 0;
            SecondPrimeGot = 0;
            combinationGot = false;
            NumForDivisGot = false;

            //let the player know his status
            textdisplayshow.text = "כל הכבוד! עכשיו תביאו לי את הלבנה שהיא הלבנה המקורית?";
            Debug.Log("line 172 - level1 - base2 - done");

            //set ok - that the mission is done
            ok = true;

            //set new level and basis
            //level = 1;
            basis = 3;

            //put the bricks into their origan places
            for (int i = 0; i < BricksPackage.Length; i++)
            {
                BricksPackage[i].transform.position = BricksOriginPosition[i];
            }

            ThirdBase();

            return ok;

        }
        return ok;

    }

    public bool ThirdBase()
    {
        bool ok = false;
        Debug.Log("im here 202" + NumForDivisGot);
        if (NumForDivisGot == true  && level == 1)
        {
            //reset checkers
            FirstPrimeGot = 0;
            SecondPrimeGot = 0;
            combinationGot = false;
            NumForDivisGot = false;

            //let the player know his status
            textdisplayshow.text = "כל הכבוד לכם! עכשיו בואו נראה האם תצליחו למצוא שילובים נוספים להרכבת הטאבון כי אני צריכה שתיים" + "\n" + "כל שעליכם לעשות זה למצוא דרך נוספת להגיע למכפלה המופיעה למעל השונה מהדרך הראשונה שמצאתם, שימו לב שייתכן שהראשוניים ישארו אותם הראשוניים ורק סדר ההכפלה ישתנה";
            Debug.Log("line 207 - level1 - base3 - done");

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

            SecondLevel();
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
            textdisplayshow.text = "כל הכבוד!!! עכשיו אני אוכל להכין יותר מטעמים וכמובן להשלים להכנת את החלק הדרוש להצלת המלל. אופן הפעולה שלכם בשיטה היה לפי מספרים פריקים, האומר שכל מספר פריק מורכב מכפל של מספרים ראשוניים" + "\n" +"נזכור שמספר פריק פירושו מספר שהוא לא ראשוני, מספר ראשוני זה מספר שמתחלק רק באחד ובעצמו."+ "\n" + "בתודה על העזרה הרבה שלכם קבלו פרס קטן זה";
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

            //SecondLevel();
            return ok;

        }
        return ok;
    }


    public void SecondLevel()
    {
        level = 2;
        //put values into bricks
        combinationprime = SecondPrime * firstPrime;
        BricksNumbersDisplay[0].text = SecondPrime.ToString();
        Debug.Log("Base1 Number: " + SecondPrime);
        BricksNumbersDisplay[1].text = firstPrime.ToString();
        Debug.Log("Base1 Number2: " + firstPrime);
        BricksNumbersDisplay[2].text = firstPrime.ToString();
        Debug.Log("Base1 Number3: " + firstPrime);
        BricksNumbersDisplay[3].text = combinationprime.ToString();
        Debug.Log("Base2 Number1: " + combinationprime);
        BricksNumbersDisplay[4].text = firstPrime.ToString();
        Debug.Log("Base2 Number2: " + firstPrime);
        BricksNumbersDisplay[5].text = NumForDivide.ToString();

        // put random values into the ohter bricks
        for (int i = 6; i < BricksNumbersDisplay.Length; i++)
        {
            BricksNumbersDisplay[i].text = randomnums().ToString();
        }

        level = 2;
        basis = 1;
        FirstBase();
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
                    Debug.Log("level1 - base1 - you find" + firstPrime + " " + FirstPrimeGot + "bricks");
                    textdisplayshow.text = " כל הכבוד, מצאת " + FirstPrimeGot + " יש להשלים את החסר";
                    return true;
                }

                //check if we got the second prime brick
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == SecondPrime && SecondPrimeGot != 1)
                {
                    SecondPrimeGot++;
                    Debug.Log("level1 - base1 - you find" + SecondPrime + " " + SecondPrimeGot + "bricks");
                    textdisplayshow.text = " מצוין, מצאת " + SecondPrimeGot + " יש להשלים את המספר הראשוני השני";
                    
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
                    Debug.Log("level1 - base2 - you find" + combinationprime );
                    textdisplayshow.text = " כל הכבוד, מצאת " + combinationprime + " עכשיו, במה תכפיל אותו כדי לקבל את המספר שבראש הטאבון?";
                    return true;
                }

                //check if we got the second prime brick
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == SecondPrime && SecondPrimeGot != 1)
                {
                    SecondPrimeGot++;
                    Debug.Log("level1 - base2 - you find" + SecondPrime + " " + SecondPrimeGot + "bricks");
                    textdisplayshow.text = " מצוין, מצאת " + SecondPrimeGot + "  עכשיו, באיזה כפולה תכפול אותו כדי לקבל את המספר שנמצא בראש הטאבון?";
                    
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
            Debug.Log("level2 - now im in the level 1 checkers");
            if (basis == 1)
            {
                Debug.Log("level2 - base1 - i check if the first base is ok ");

                //check if we got to first prime bricks
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == SecondPrime && FirstPrimeGot < 2)
                {
                    FirstPrimeGot++;
                    Debug.Log("level2 - base1 - you find" + SecondPrime + " " + SecondPrimeGot + "bricks");
                    textdisplayshow.text = " איזה יופי, מצאת " + SecondPrimeGot + " יש להשלים את החסר";
                    return true;
                }

                //check if we got the second prime brick
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == firstPrime && SecondPrimeGot != 1)
                {
                    SecondPrimeGot++;
                    Debug.Log("level2 - base1 - you find" + firstPrime + " " + FirstPrimeGot + "bricks");
                    textdisplayshow.text = " נהדר, מצאת " + FirstPrimeGot + " יש להשלים את המספר הראשוני השני";
                    
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
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == combinationprime && combinationGot == false)
                {
                    combinationGot = true;
                    Debug.Log("level2 - base2 - you find" + combinationprime);
                    textdisplayshow.text = " נדיר, מצאת " + combinationprime + " עכשיו, במה תכפיל אותו כדי לקבל את המספר שבראש הטאבון?";
                    return true;
                }

                //check if we got the second prime brick
                if (brick.GetComponent<NumberAtBrick>().NumAtBrick() == firstPrime && SecondPrimeGot != 1)
                {
                    FirstPrimeGot++;//at 21.1.2021 it was second primegot
                    Debug.Log("level2 - base2 - you find" + firstPrime + " " + FirstPrimeGot + "bricks");
                    textdisplayshow.text = " יופידו!, מצאת " + FirstPrimeGot + "  עכשיו, באיזה כפולה תכפול אותו כדי לקבל את המספר שנמצא בראש הטאבון?";
                    
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

