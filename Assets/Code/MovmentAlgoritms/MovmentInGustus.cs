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
            Vector3 move = transform.position + Vector3.left * Time.deltaTime * speed;
            if (transform.position.x < -10.40903 || move.x < -10.40903)
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
            Vector3 move = transform.position + Vector3.right * Time.deltaTime * speed;
            if (transform.position.x < 10.29758 || move.x < 10.29758)
                return transform.position + Vector3.right * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //down movment limit -1.62365
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 move = transform.position + Vector3.down * Time.deltaTime * speed;
            if (transform.position.y > -1.62365 || move.y > -1.62365)
                return transform.position + Vector3.down * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //up (not included jump function) movment limit -0.4098668
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 move = transform.position + Vector3.up * Time.deltaTime * speed;
            if (transform.position.y < -0.4098668 || move.y < -0.4098668)
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
