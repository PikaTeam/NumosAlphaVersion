using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionOnStart : MonoBehaviour
{
  
    private void Start()
    {
        if (Location.LocSaver.ContainsKey(SceneManager.GetActiveScene().name))
            {
            transform.position = Location.LocSaver[SceneManager.GetActiveScene().name];
            }
       

    }
}
