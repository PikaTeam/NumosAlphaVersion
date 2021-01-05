using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyGui : MonoBehaviour , IObserver<int>
{
    public TextMeshProUGUI textdisplay;
    Money amountofmouny;
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

    public void setamount(Money amount)
    {
        this.amountofmouny = amount;
        MemmberManger = amountofmouny.Subscribe(this);

    }

    private void OnDestroy()
    {
        if (MemmberManger != null)
        {
            MemmberManger.Dispose();
        }

    }
}
