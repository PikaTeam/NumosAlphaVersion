using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    public string triggeringTag;
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(triggeringTag))
        {
            var scene = SceneManager.GetSceneByName(sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }
}
