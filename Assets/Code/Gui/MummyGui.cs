using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class MummyGui : MonoBehaviour, IObserver <int>
{
    public TextMeshProUGUI textdisplay;
    MummyCaught countofmummy;
    IDisposable MemmberManger;

public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(int value)
    {
        textdisplay.text = value.ToString();
     }

    public void setcaught(MummyCaught caught)
    {
        this.countofmummy = caught;
        MemmberManger =  countofmummy.Subscribe(this);

    }

    private void OnDestroy()
    {
        if (MemmberManger != null)
        {
            MemmberManger.Dispose();
        }

    }
}

