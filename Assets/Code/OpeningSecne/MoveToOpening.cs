using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveToOpening : MonoBehaviour
{
    // Start is called before the first frame update
    protected Vector3 NewPosition()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Egypte");
            return transform.position;
        }
        else
            return transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = NewPosition();
    }
}