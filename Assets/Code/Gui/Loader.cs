using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public LifeBarManger gui;
    public MummyGui mgui;
    public MoneyGui mogui;
    public SCoreGui sgui;

   




    // Start is called before the first frame update
    void Start()
    {
        PlayerStatusData data = SingleToon.getInstance();
        mgui.setcaught(data.curmummycaght);
        gui.setlife(data.curlife);
        mogui.setamount(data.curmoney);
        sgui.setamount(data.curscore);
        //data.curlife.damage(20);


        MissionStatus info = SingleToon.getState();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
