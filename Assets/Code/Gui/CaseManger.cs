using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseManger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static char getpushedkey()
    {
        //check if a have been pushed
        if (Input.GetKey(KeyCode.A))
        {
            return 'A';
        }

        //check if b have been pushed
        if (Input.GetKey(KeyCode.B))
        {
            return 'B';
        }

        //check if c have been pushed
        if (Input.GetKey(KeyCode.C))
        {
            return 'C';
        }

        //check if d have been pushed
        if (Input.GetKey(KeyCode.D))
        {
            return 'D';
        }

        else
            //meaning that nofing have been pushed.
            return 'n';

    }
}
