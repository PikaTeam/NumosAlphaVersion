using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : IObservable<int>
{
    int currentmoney = 0;
    private List<IObserver<int>> observers = new List<IObserver<int>>();

    private void notify()
    {
        foreach (IObserver<int> OBS in observers)
        {
            OBS.OnNext(currentmoney);
        }
    }

    public void spend(int value)
    {
        currentmoney = currentmoney - value;
        notify();
    }

    public void gain(int value)
    {
        currentmoney = currentmoney + value;
        notify();

    }

    public IDisposable Subscribe(IObserver<int> observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);
        observer.OnNext(currentmoney);
        return new Unsubscriber(observers, observer);
    }

    private class Unsubscriber : IDisposable
    {
        private List<IObserver<int>> _observers;
        private IObserver<int> _observer;

        public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }


}
