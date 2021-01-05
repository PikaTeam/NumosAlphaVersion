using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SCoreGui : MonoBehaviour, IObserver<int>
{
    public TextMeshProUGUI textdisplay;
    Score scorevalue;
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

    public void setamount(Score amount)
    {
        this.scorevalue = amount;
        MemmberManger = scorevalue.Subscribe(this);

    }

    private void OnDestroy()
    {
        if (MemmberManger != null)
        {
            MemmberManger.Dispose();
        }

    }
}
