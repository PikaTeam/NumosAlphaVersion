using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionStatus : MonoBehaviour
{
    public LaFarmaMission StatusLaFarma;
    public GuassMission StatusGuass;
    public MummyMission StatusMummy;
  


    public MissionStatus()
    {
        StatusLaFarma = new LaFarmaMission();
        StatusGuass = new GuassMission();
        StatusMummy = new MummyMission();
    }
}
