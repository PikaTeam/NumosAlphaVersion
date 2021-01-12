using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Location 
{
    public static Dictionary<string, Vector2> LocSaver = new Dictionary<string, Vector2>();

    public static void SaveLocation(Vector2 postion)
    {
        if (LocSaver.ContainsKey(SceneManager.GetActiveScene().name))
        {
            LocSaver[SceneManager.GetActiveScene().name] = postion;
        }
        else
        {
            LocSaver.Add(SceneManager.GetActiveScene().name, postion);
        }
    }

}
