using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOnClick : MonoBehaviour
{
    public GameObject MainObject;
    private void OnMouseDown()
    {
        MainObject.GetComponent<SolutionValidator>().ValidateAnswer();
    }
}
