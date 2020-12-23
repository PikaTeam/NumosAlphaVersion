using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovmentAtLaFarma : MonoBehaviour
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
        //left movment limit -13.6223 , go back to egypte
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            double LeftLimitWall = -12.97418;
            Vector3 move = transform.position + Vector3.left * Time.deltaTime * speed;
            if (transform.position.x < LeftLimitWall || move.x < LeftLimitWall)
            {
                SceneManager.LoadScene("Egypte");
                return transform.position;
            }

            else
                return transform.position + Vector3.left * Time.deltaTime * speed;
        }

        //right movment limit 13.33466
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            double LimitRightWall = 11.86134;
            Vector3 move = transform.position + Vector3.right * Time.deltaTime * speed;
            if (transform.position.x < LimitRightWall || move.x < LimitRightWall)
                return transform.position + Vector3.right * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //down movment limit -2.355071
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            double LimitBottom = -2.355071;
            Vector3 move = transform.position + Vector3.down * Time.deltaTime * speed;
            if (transform.position.y > LimitBottom || move.y > LimitBottom)
                return transform.position + Vector3.down * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //up (not included jump function) movment limit -1.55
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            double LimitTop = -1.55;
            Vector3 move = transform.position + Vector3.up * Time.deltaTime * speed;
            if (transform.position.y < LimitTop || move.y < LimitTop)
                return transform.position + Vector3.up * Time.deltaTime * speed;

            else
                return transform.position;
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

