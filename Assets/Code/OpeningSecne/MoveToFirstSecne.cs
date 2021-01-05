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

    public void infoHome()
    {
        SceneManager.LoadScene("Info");
    }


    public void options()
    {
        SceneManager.LoadScene("Options");
    }

    public void opening ()
    {
        SceneManager.LoadScene("Opening");
    }   
    

    public void continues ()
    {
        SceneManager.LoadScene("Egypte");//change it to time scale = 1; now the func no really works
    }

    public void Lafarma()
    {
        SceneManager.LoadScene("LaFarma");//change it to time scale = 1; now the func no really works
    }


}
