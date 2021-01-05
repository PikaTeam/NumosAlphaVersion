using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseQuest : MonoBehaviour
{
    public void Close()
    {
        // 1. Resume game activity.
        // 2. Destory the quest object (assuimg that quest obj = self).

        // TODO
        Debug.Log("Closed quest");
        Destroy(gameObject);
       
    }
}
