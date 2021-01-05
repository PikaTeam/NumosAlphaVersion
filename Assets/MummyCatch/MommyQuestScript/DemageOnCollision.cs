using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemageOnCollision : MonoBehaviour
{
    public string tag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag==tag)
        {
            Debug.Log("im here to demage");
            SingleToon.getInstance().curlife.damage(5);
        }
    }
}
