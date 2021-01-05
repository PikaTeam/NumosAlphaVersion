using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : IObservable<int>
{
    int currentlife = 100;
    private List<IObserver<int>> observers = new List<IObserver<int>>();

    private void notify()
    {
        foreach (IObserver<int> OBS in observers)
        {
            OBS.OnNext(currentlife);
        }
    }

    public void damage (int hit)
    {
        currentlife = currentlife - hit;
        notify();
    }

    public void heal (int health)
    {
        if (currentlife < 100 && currentlife > 0)
        {
            currentlife = currentlife + health;

        }
        else
            currentlife = currentlife + 0;

        notify();

    }

    public IDisposable Subscribe(IObserver<int> observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);
        observer.OnNext(currentlife);
        return new Unsubscriber(observers, observer);
    }

    private class Unsubscriber : IDisposable
   {
      private List<IObserver<int>>_observers;
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
