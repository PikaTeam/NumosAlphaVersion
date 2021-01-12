using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SingleToon
{

    //save the object that is incharge on my elemnts
    private static PlayerStatusData instance;

    ///added at 7/1/21
    private static MissionStatus State;
    ///

    private SingleToon(){ }

    public static PlayerStatusData getInstance()
    {
        if (instance == null)
        {
            instance = new PlayerStatusData();
        }
        return instance;
        
    }

    ///added at 7/1/21
    public static MissionStatus getState()
    {
        if (State == null)
        {
            State = new MissionStatus();
        }
        return State;

    }
    ///

    public static void reset()
    {

        instance = null;


    }






}
