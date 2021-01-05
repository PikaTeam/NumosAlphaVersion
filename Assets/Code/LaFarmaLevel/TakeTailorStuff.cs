using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTailorStuff : MonoBehaviour
{
    public string tag;
    public string LaFarmaTag;
    public GameObject Stuff;
    public Transform StuffParent;
    public bool IsAdoptedStuff = false;
    bool TouchLittleFarma = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tag)
        {
            //T key down -> take staff
            if (Input.GetKeyDown(KeyPanel.Take))
            {
                if (IsAdoptedStuff == false)
                {
                    Stuff = collision.gameObject;
                    StuffParent = collision.transform.parent;
                    collision.gameObject.transform.parent = this.transform;
                    collision.gameObject.transform.localPosition = Vector3.zero;
                    IsAdoptedStuff = true;
                    Debug.Log("here with la farma 28");

                }

            }


        }

        if (collision.gameObject.tag == LaFarmaTag)
        {
            TouchLittleFarma = true;
            if (IsAdoptedStuff == true)
            {

                if (Input.GetKeyDown(KeyPanel.Put))
                {
                    float height;
                    IsAdoptedStuff = false;
                    bool currectstuff = false;
                    int currectLevel = collision.gameObject.GetComponent<RandomeNumbers>().level;
                    Stuff.transform.parent = StuffParent;
                    height = this.GetComponent<SpriteRenderer>().bounds.size.y;
                    Stuff.transform.position = new Vector3(transform.position.x, transform.position.y - (height / 4) , transform.position.z);
                    currectstuff = collision.gameObject.GetComponent<RandomeNumbers>().checkifcurrect(Stuff);
                    Debug.Log("line 52 is currect? " + currectstuff);

                    if (currectstuff == true && currectLevel == 1)
                    {
                        collision.gameObject.GetComponent<RandomeNumbers>().FirstLevel();
                        currectstuff = false;
                    }

                    if (currectstuff == true && currectLevel == 2)
                    {
                        collision.gameObject.GetComponent<RandomeNumbers>().SecondLevel();
                        currectstuff = false;
                    }

                    if (currectstuff == true && currectLevel == 3)
                    {
                        collision.gameObject.GetComponent<RandomeNumbers>().thirdLevel();
                        currectstuff = false;
                    }
                }



            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == LaFarmaTag)
        {
            TouchLittleFarma = false;
        }
    }



    private void Update()
    {
        if (TouchLittleFarma != true)
        {
            //G key down -> take staff
            if (Input.GetKeyDown(KeyPanel.Put))
            {
                if (IsAdoptedStuff == true)
                {
                    float height;
                    IsAdoptedStuff = false;
                    Stuff.transform.parent = StuffParent;
                    height = this.GetComponent<SpriteRenderer>().bounds.size.y;
                    Stuff.transform.position = new Vector3(transform.position.x, transform.position.y - height / 4 , transform.position.z);
                    Debug.Log("mon bian 89: " + Stuff.transform.position);

                }

            }
        }

    }
}
