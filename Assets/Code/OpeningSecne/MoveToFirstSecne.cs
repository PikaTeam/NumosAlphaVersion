using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToFirstSecne : MonoBehaviour
{
    public void Begin()
    {
        SceneManager.LoadScene("Egypte");
    }


    public void info()
    {
        SceneManager.LoadScene("Instructions");
    }


    public void options()
    {
        SceneManager.LoadScene("Egypte");
    }
}
