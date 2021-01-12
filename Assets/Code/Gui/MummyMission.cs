using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyMission : MonoBehaviour
{
    bool CurrectAnswer = false;

    public void currect(bool Acomplish)
    {
        CurrectAnswer = true;
        //notify();
    }

    public void uncurrect(bool notacomplish)
    {
        CurrectAnswer = false;
        //notify();
    }
}
