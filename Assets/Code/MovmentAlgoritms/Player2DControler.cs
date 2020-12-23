using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2DControler : MonoBehaviour
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
        //left movment limit 44.04
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 move = transform.position + Vector3.left * Time.deltaTime * speed;
            if (transform.position.x > -66.55 || move.x > -66.55)
                return transform.position + Vector3.left * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //right movment limit 169.3
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 move = transform.position + Vector3.right * Time.deltaTime * speed;
            if (transform.position.x < 130.45 || move.x < 130.45)
                return transform.position + Vector3.right * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //down movment limit -5.3
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 move = transform.position + Vector3.down * Time.deltaTime * speed;
            if (transform.position.y > -5.3 || move.y > -5.3)
                return transform.position + Vector3.down * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //up (not included jump function) movment limit -3.08
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 move = transform.position + Vector3.up * Time.deltaTime * speed;
            if (transform.position.y < -3.36 || move.y < -3.36)
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
            Vector3 move = transform.position + Vector3.down;
            if (transform.position.x < -13.55 && transform.position.x > -15.55)
            {
                SceneManager.LoadScene("LaFarma");
                return transform.position + move; //ToDo Pass into ohter secne
                //Debug.Log("we are the chmpions");
            }

            if (transform.position.x > 54.45 && transform.position.x < 58.45)
            {
                SceneManager.LoadScene("GuessTaste");
                return transform.position;
                //return transform.position + move; //ToDo Pass into ohter secne
            }


            if (transform.position.x > 114.45)
            {
                SceneManager.LoadScene("LaFarma");
                return transform.position;
                //return transform.position + move; //ToDo Pass into ohter secne
            }

            else
                return transform.position;
        
       
        }


        /*//B key down -> throwing bandage on the mommy
        else if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("b"))

        {
            Vector3 move = transform.position + Vector3.down;
            if (transform.position.x > -13.55 && transform.position.x < -15.55)
                return transform.position + move; //ToDo Pass into ohter secne
            else
                return transform.position;
        }*/


        

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
    