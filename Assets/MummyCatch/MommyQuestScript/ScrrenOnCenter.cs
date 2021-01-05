using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrrenOnCenter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, +10)));

    }
}
