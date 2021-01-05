using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBandget2 : MonoBehaviour
{
    public GameObject Bandge;
    public float Speed = 0.3f;
    
    public void Update()
    {
         if (Input.GetKeyDown(KeyPanel.ThrowBandage))
        {
            GameObject Band = Instantiate(Bandge,transform.position,new Quaternion());
            int direction = 1; // TODO: make the direction be the direction that the character faces / last moved to.
                               // can be part of the character controller.
            Band.GetComponent<Rigidbody2D>().velocity = Vector2.right * Speed * direction
                                                        + Vector2.up * 5;

            

            
        }
    }

   
}
