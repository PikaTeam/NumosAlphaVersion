using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBandget : MonoBehaviour
{
    public GameObject Bandge;
    public float Speed = 0.3f;
    
    public void Update()
    {



         if (Input.GetKeyDown(KeyPanel.ThrowBandage))
        {
            GameObject Band = Instantiate(Bandge,transform.position,new Quaternion());
            Band.GetComponent<Rigidbody2D>().velocity = Vector2.right * Speed;

        }
    }

   
}
