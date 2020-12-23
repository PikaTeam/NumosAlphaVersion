using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class OldMovmentTye2Dcontroler : MonoBehaviour
{

    //jumping
    public float jumpForce = 10;
    public float jumpForceEffectByMomentomRatio;
    public float speed = 4f;

    // Start is called before the first frame update
    /* void Start()
     {

     }*/

    protected Vector3 NewPosition()
    {
        //left movment limit -66.55
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            double LeftLimitWall = -66.55;
            Vector3 move = transform.position + Vector3.left * Time.deltaTime * speed;
            if (transform.position.x > LeftLimitWall || move.x > LeftLimitWall)
                return transform.position + Vector3.left * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //right movment limit 130.45
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            double LimitRightWall = 130.45;
            Vector3 move = transform.position + Vector3.right * Time.deltaTime * speed;
            if (transform.position.x < LimitRightWall || move.x < LimitRightWall)
                return transform.position + Vector3.right * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //down movment limit -5.3
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            double LimitBottom = -5.3;
            Vector3 move = transform.position + Vector3.down * Time.deltaTime * speed;
            if (transform.position.y > LimitBottom || move.y > LimitBottom)
                return transform.position + Vector3.down * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //up (not included jump function) movment limit -3.36
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            double LimitTop = -3.36;
            Vector3 move = transform.position + Vector3.up * Time.deltaTime * speed;
            if (transform.position.y < LimitTop || move.y < LimitTop)
                return transform.position + Vector3.up * Time.deltaTime * speed;

            /*//the palace place ,make him go up stairs
            if (transform.position.x < -40.55 || transform.position.x > -62.55)
            {
                if (transform.position.y < 1)
                    return transform.position + Vector3.up * Time.deltaTime * speed;
                else
                    return transform.position;
            }*/

            else
                return transform.position;
        }



        /*//jump   //ToDO - the problem is when we do pisic it takes the player under the ground and we dont want it so it problamtic.
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 move = transform.position + Vector3.up;
            if (transform.position.y < -3.36 || move.y < -3.36)
                return transform.position + Vector3.up;
            else
                return transform.position;
        }*/


        //H key down -> getting into places
        else if (Input.GetKeyDown(KeyCode.H) || Input.GetKey("h"))

        {
            double rightEnternceLaFarmaBaginDistance = -15.55;
            double leftEnternceLfarmaEndDistance = -13.55;
            Vector3 move = transform.position + Vector3.down;
            if (transform.position.x < leftEnternceLfarmaEndDistance && transform.position.x > rightEnternceLaFarmaBaginDistance)
            {
                SceneManager.LoadScene("LaFarma");
                return transform.position; //ToDo Pass into ohter secne
                //Debug.Log("we are the chmpions");
            }

            double rightEnternceGuessTasteaBaginDistance = 54.45;
            double leftEnternceGuessTasteEndDistance = 58.45;
            if (transform.position.x > rightEnternceGuessTasteaBaginDistance && transform.position.x < leftEnternceGuessTasteEndDistance)
            {
                SceneManager.LoadScene("GuessTaste");
                return transform.position;
                //return transform.position + move; //ToDo Pass into ohter secne
            }

            //right now the shop is not ready yet so it sends you temporary to la farma
            double PlusShopLimitEnternce = 114.45;
            if (transform.position.x > PlusShopLimitEnternce)
            {
                SceneManager.LoadScene("LaFarma");
                return transform.position;
                //return transform.position + move; //ToDo Pass into ohter secne
            }

            else
                return transform.position;


        }

        //I key down -> getting into places
        else if (Input.GetKeyDown(KeyCode.I) || Input.GetKey("i"))
        {
            SceneManager.LoadScene("Instructions");
            return transform.position;
        }


        //if nofing preesed
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

