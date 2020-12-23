using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovmentAtTabonChallange : MonoBehaviour
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
        //leftMovement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return transform.position + Vector3.left * Time.deltaTime * speed;
        }

        //RightMovement
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            return transform.position + Vector3.right * Time.deltaTime * speed;
        }

        //DownMovement
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            return transform.position + Vector3.down * Time.deltaTime * speed;
        }

        //UpMovement
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            return transform.position + Vector3.up * Time.deltaTime * speed;
        }

        //H key down -> getting into places
        else if (Input.GetKeyDown(KeyCode.H) || Input.GetKey("h"))

        {
            double rightEnternceBackGustusBaginDistance = -4.721267;
            double leftEnternceBackGustuseEndDistance = -7.504583;
            Vector3 move = transform.position + Vector3.down;
            if (transform.position.x > leftEnternceBackGustuseEndDistance && transform.position.x < rightEnternceBackGustusBaginDistance)
            {
                SceneManager.LoadScene("GuessTaste");
                return transform.position; //ToDo Pass into ohter secne
                //Debug.Log("we are the chmpions");
            }

            else
            {
                return transform.position;
            }
        }

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
