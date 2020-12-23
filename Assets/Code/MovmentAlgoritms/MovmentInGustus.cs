using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovmentInGustus : MonoBehaviour
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
        //left movment limit -10.40903 , go back to egypte
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            double LeftLimitWall = -10.40903;
            Vector3 move = transform.position + Vector3.left * Time.deltaTime * speed;
            if (transform.position.x < LeftLimitWall || move.x < LeftLimitWall)
            {
                SceneManager.LoadScene("Egypte");
                return transform.position;
            }

            else
                return transform.position + Vector3.left * Time.deltaTime * speed;
        }

        //right movment limit 10.29758
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            double LimitRightWall = 10.29758;
            Vector3 move = transform.position + Vector3.right * Time.deltaTime * speed;
            if (transform.position.x < LimitRightWall || move.x < LimitRightWall)
                return transform.position + Vector3.right * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //down movment limit -1.62365
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            double LimitBottom = -1.6236;
            Vector3 move = transform.position + Vector3.down * Time.deltaTime * speed;
            if (transform.position.y > LimitBottom || move.y > LimitBottom)
                return transform.position + Vector3.down * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //up (not included jump function) movment limit -0.4098668
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            double LimitTop = -0.4098668;
            Vector3 move = transform.position + Vector3.up * Time.deltaTime * speed;
            if (transform.position.y < LimitTop || move.y < LimitTop)
                return transform.position + Vector3.up * Time.deltaTime * speed;

            else
                return transform.position;
        }

        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKey("a"))
        {
                SceneManager.LoadScene("GuessTasteTabon");
                return transform.position; //ToDo Pass into ohter secne
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
