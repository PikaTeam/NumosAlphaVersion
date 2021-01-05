using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBrick : MonoBehaviour
{
    public string tag; 
    public string PyrmidTag;
    public GameObject Brick;
    public Transform BrickParent;
    public bool IsAdoptedBrick = false;
    bool hitpyrmid = false;
    int CurrectBrickFirstLevelBase1 = 0;
    int CurrectBrickFirstLevelBase2 = 0;
    int CurrectBrickFirstLevelBase3 = 0;
    public int a = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tag)
        {
            //T key down -> take staff
            if (Input.GetKeyDown(KeyPanel.Take))
            {
                if (IsAdoptedBrick == false)
                {
                    Brick = collision.gameObject;
                    BrickParent = collision.transform.parent;
                    collision.gameObject.transform.parent = this.transform;
                    collision.gameObject.transform.localPosition = Vector3.zero;
                    IsAdoptedBrick = true;
                    Debug.Log("we did it");

                }

            }


        }

        if (collision.gameObject.tag == PyrmidTag)
        {
            hitpyrmid = true;
            if (IsAdoptedBrick == true)
            {
                
                if (Input.GetKeyDown(KeyPanel.Put))
                {
                    float height;
                    IsAdoptedBrick = false;
                    bool currectbrick = false;
                    Brick.transform.parent = BrickParent;
                    int currectLevel = collision.gameObject.GetComponent<NumberSuffleForGuasstaste>().level;
                    int CurrectBase = collision.gameObject.GetComponent<NumberSuffleForGuasstaste>().basis;
                    height = this.GetComponent<SpriteRenderer>().bounds.size.y;
                    Brick.transform.position = new Vector3(transform.position.x, transform.position.y - height / 2, transform.position.z);
                    currectbrick = collision.gameObject.GetComponent<NumberSuffleForGuasstaste>().CheckIfCorrect(Brick, currectLevel);
                    Debug.Log("is currect? " + currectbrick);

                    if (currectbrick==true && CurrectBase == 1)
                    {
                        a++;
                        Debug.Log("the value of a in base 1 is: " + a);
                        CurrectBrickFirstLevelBase2 = CurrectBrickFirstLevelBase2 + 1;
                        Debug.Log("you have been puten: " + CurrectBrickFirstLevelBase2);
                    }

                    if (currectbrick == true && CurrectBase ==2)
                    {
                        a++;
                        Debug.Log("the value of a in base 2 is: " + a);
                    }

                    if (currectbrick == true && CurrectBase == 3)
                    {
                        a++;
                        Debug.Log("the value of a in base 3 is: " + a);
                    }



                    //Debug.Log("after the first level thev value is:" + CurrectBrickFirstLevelBase2);

                    if (a == 3 && currectLevel == 1 && CurrectBase == 1)
                    {
                        collision.gameObject.GetComponent<NumberSuffleForGuasstaste>().FirstBase();
                        Debug.Log("you get it 74");
                        a = 0;
                    }

                    if (a == 2 && currectLevel == 1 && CurrectBase == 2)
                    {
                        collision.gameObject.GetComponent<NumberSuffleForGuasstaste>().SecondBase();
                        CurrectBrickFirstLevelBase2 = 0;
                        Debug.Log("you get it 82");
                        a = 0;

                    }

                    if (a == 1 && currectLevel == 1 && CurrectBase == 3)
                    {
                        CurrectBrickFirstLevelBase2 = 0;
                        a = 0;
                        Debug.Log("you get it 92");
                        collision.gameObject.GetComponent<NumberSuffleForGuasstaste>().ThirdBase();
                    }

                    //////Level2////////////////////

                    if (a == 3 && currectLevel == 2 && CurrectBase == 1)
                    {
                        collision.gameObject.GetComponent<NumberSuffleForGuasstaste>().FirstBase();
                        Debug.Log("you get it 74");
                        a = 0;
                    }

                    if (a == 2 && currectLevel == 2 && CurrectBase == 2)
                    {
                        collision.gameObject.GetComponent<NumberSuffleForGuasstaste>().SecondBase();
                        CurrectBrickFirstLevelBase2 = 0;
                        Debug.Log("you get it 82");
                        a = 0;

                    }

                    if (a == 1 && currectLevel == 2 && CurrectBase == 3)
                    {
                        CurrectBrickFirstLevelBase2 = 0;
                        a = 0;
                        Debug.Log("you get it 92");
                        collision.gameObject.GetComponent<NumberSuffleForGuasstaste>().ThirdBase();
                    }



                }
            }
            //hitpyrmid = false;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == PyrmidTag)
        {
            hitpyrmid = false;
        }
    }



    private void Update()
    {
        if (hitpyrmid != true)
        {
            //G key down -> take staff
            if (Input.GetKeyDown(KeyPanel.Put))
            {
                if (IsAdoptedBrick == true)
                {
                    float height;
                    IsAdoptedBrick = false;
                    Brick.transform.parent = BrickParent;
                    height = this.GetComponent<SpriteRenderer>().bounds.size.y;
                    Brick.transform.position = new Vector3(transform.position.x, transform.position.y - height / 2, transform.position.z);
                    Debug.Log("we did it again: " + Brick.transform.position);

                }

            }
        }
        
    }
}
