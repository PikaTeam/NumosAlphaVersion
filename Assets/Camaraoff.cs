using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaraoff : MonoBehaviour
{
    public Camera offcamara;
    // Start is called before the first frame update
    void Start()
    {
        offcamara.gameObject.SetActive(true); ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
