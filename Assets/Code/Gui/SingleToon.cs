using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SingleToon
{

    //save the object that is incharge on my elemnts
    private static PlayerStatusData instance;

    private SingleToon(){ }

    public static PlayerStatusData getInstance()
    {
        if (instance == null)
        {
            instance = new PlayerStatusData();
        }
        return instance;
        
    }

    public static void reset()
    {

        instance = null;


    }






}
