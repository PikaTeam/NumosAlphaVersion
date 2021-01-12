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


    //for coliision use
    public bool isGrounded = false;
    public bool canMomentumJump = false;
    public LayerMask groundLayer;

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


        //H key down -> getting into places
        else if (Input.GetKeyDown(KeyPanel.EnterToPlaces))

        {
            double rightEnternceLaFarmaBaginDistance = -15.55;
            double leftEnternceLfarmaEndDistance = -13.55;
            Vector3 move = transform.position + Vector3.down;
            if (transform.position.x < leftEnternceLfarmaEndDistance && transform.position.x > rightEnternceLaFarmaBaginDistance)
            {
                Location.SaveLocation(transform.position);
                SceneManager.LoadScene("LaFarma");
                return transform.position; //ToDo Pass into ohter secne
                //Debug.Log("we are the chmpions");
            }

            double rightEnternceGuessTasteaBaginDistance = 54.45;
            double leftEnternceGuessTasteEndDistance = 58.45;
            if (transform.position.x > rightEnternceGuessTasteaBaginDistance && transform.position.x < leftEnternceGuessTasteEndDistance)
            {
                Location.SaveLocation(transform.position);
                SceneManager.LoadScene("GuessTaste");
                return transform.position;
                //return transform.position + move; //ToDo Pass into ohter secne
            }

            //right now the shop is not ready yet so it sends you temporary to la farma
            double PlusShopLimitEnternce = 114.45;
            if (transform.position.x > PlusShopLimitEnternce)
            {
                Location.SaveLocation(transform.position);
                SceneManager.LoadScene("PlusShop");
                return transform.position;
                //return transform.position + move; //ToDo Pass into ohter secne
            }

            else
                return transform.position;
        
       
        }


        //I key down -> getting info
        else if (Input.GetKeyDown(KeyCode.I) || Input.GetKey("i"))
        {
            SceneManager.LoadScene("Instructions");
            return transform.position;
        }

        //M key down -> open invatory
        else if (Input.GetKeyDown(KeyCode.M))
        { 
            Instantiate(InvatoryForUSe);
            return transform.position;
        }

        /* //T key down -> taking things in levels
         else if (Input.GetKeyDown(KeyCode.T) || Input.GetKey("t"))
         {
             //need to put here an option to take object and clone it
             //plas return the posion of him and find what is the value inside of him.
             SceneManager.LoadScene("Instructions");
             return transform.position;
         }

         //G key down -> giving things in levels
         else if (Input.GetKeyDown(KeyCode.G) || Input.GetKey("g"))
         {
             //need to put here an option to gave object and destroy it
             SceneManager.LoadScene("Instructions");
             return transform.position;
         }*/

        //P key down -> giving things in levels
        else if (Input.GetKeyDown(KeyCode.P) || Input.GetKey("p"))
        {
            //need to put here an option to gave object and destroy it
            SceneManager.LoadScene("PausePage");
            return transform.position;
        }


        //if nofing preesed
        else
        {
            return transform.position;
        }





    }

    void FixedUpdate()
    {
        /*bool isTouchingGround = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, -0.6f), 0.2f, groundLayer);
        isGrounded = isTouchingGround && rb2d.velocity.y < 0.1;
        bool isNearGroundF = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, -0.85f), 0.4f, groundLayer);
        if (isNearGroundF && rb2d.velocity.y < -1)
            canMomentumJump = true;
        else canMomentumJump = false;


        Debug.Log("is GROUNDED: " + isGrounded);*/
    }


    // Update is called once per frame
    void Update()
    {
                transform.position = NewPosition();
    }

    
}
