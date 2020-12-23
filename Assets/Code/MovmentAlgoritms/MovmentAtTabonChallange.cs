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
        //left movment limit -13.57991 , go back to egypte
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 move = transform.position + Vector3.left * Time.deltaTime * speed;
            if (transform.position.x > -13.57991 || move.x > -13.57991)
            {
                return transform.position + Vector3.left * Time.deltaTime * speed;

            }

            else
                return transform.position;
        }

        //right movment limit 13.4
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 move = transform.position + Vector3.right * Time.deltaTime * speed;
            if (transform.position.x < 13.4 || move.x < 13.4)
                return transform.position + Vector3.right * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //down movment limit -1.828051
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 move = transform.position + Vector3.down * Time.deltaTime * speed;
            if (transform.position.y > -1.828051 || move.y > -1.828051)
                return transform.position + Vector3.down * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //up (not included jump function) movment limit -1.55
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 move = transform.position + Vector3.up * Time.deltaTime * speed;
            if (transform.position.y < -1 || move.y < -1)
                return transform.position + Vector3.up * Time.deltaTime * speed;

            else
                return transform.position;
        }

        //H key down -> getting into places
        else if (Input.GetKeyDown(KeyCode.H) || Input.GetKey("h"))

        {
            Vector3 move = transform.position + Vector3.down;
            if (transform.position.x > -7.504583 && transform.position.x < -4.721267)
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
