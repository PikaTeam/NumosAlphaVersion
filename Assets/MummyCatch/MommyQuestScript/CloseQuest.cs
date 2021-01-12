using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseQuest : MonoBehaviour
{
    public GameObject Mymummy;
    
    public void Close(bool status)
    {
        
        // 1. Resume game activity.
        // 2. Destory the quest object (assuimg that quest obj = self).

        // TODO
        
        if (status == true)
        {
            Destroy(Mymummy);
            Debug.Log("mummy is: " + Mymummy);
        }

        Debug.Log("Closed quest");
        Destroy(gameObject);

    }
}
