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
            Vector3 move = transform.position + Vector3.left * Time.deltaTime * speed;
            if (transform.position.x < -13.6223 || move.x < -13.6223)
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
            Vector3 move = transform.position + Vector3.right * Time.deltaTime * speed;
            if (transform.position.x < 13.33466 || move.x < 13.33466)
                return transform.position + Vector3.right * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //down movment limit -2.355071
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 move = transform.position + Vector3.down * Time.deltaTime * speed;
            if (transform.position.y > -2.355071 || move.y > -2.355071)
                return transform.position + Vector3.down * Time.deltaTime * speed;
            else
                return transform.position;
        }

        //up (not included jump function) movment limit -1.55
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 move = transform.position + Vector3.up * Time.deltaTime * speed;
            if (transform.position.y < -1.55 || move.y < -1.55)
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

