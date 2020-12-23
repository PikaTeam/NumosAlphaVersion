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

        //click on A
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
