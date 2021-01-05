using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LifeBarManger : MonoBehaviour, IObserver<int>
{
    public Image lifebar;
    public Image manabar;
    public Text lifetext;
    public Text manatexst;

    public float life;
    public float mana;
    public Life live;
    IDisposable MemmberManger;

    private float currentlife;
    private float currentmana;
    private float calcalutelife;

    // Start is called before the first frame update
    void Start()
    {

        currentlife = life;

    }


    // Update is called once per frame
    void Update()
    {
        calcalutelife = currentlife / life;
        //lifebar.fillAmount = Mathf.MoveTowards(lifebar.fillAmount, calcalutelife, Time.deltaTime);
        lifebar.fillAmount = Mathf.MoveTowards(lifebar.fillAmount, calcalutelife, Time.deltaTime);
        //lifetext.text = " " + (int)currentlife;
        //Debug.Log("the current life is: " + currentlife);

        if (currentlife <=0)
        {
            
            SceneManager.LoadScene("Restart");
            SingleToon.reset();
            currentlife = 0;
            
        }

        //manatexst.text = " " + Mathf.FloorToInt(currentmana);
    }

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
        currentlife = value;
    }

    public void setlife (Life live)
    {
        this.live = live;
        MemmberManger = live.Subscribe(this);

    }

    private void OnDestroy()
    {
        if(MemmberManger != null)
        {
            MemmberManger.Dispose();
        }
       
    }
}

