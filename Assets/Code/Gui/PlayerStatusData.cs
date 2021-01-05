using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusData 
{
    //this is class is DTO, he just transfer data.
    public Life curlife;
    public Money curmoney;
    public Score curscore;
    public MummyCaught curmummycaght;


    public PlayerStatusData()
    {
        curlife = new Life();
        curmoney = new Money();
        curscore = new Score();
        curmummycaght = new MummyCaught();
    }


}
 