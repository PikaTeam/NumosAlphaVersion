using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ResumeTimeOnDestory : MonoBehaviour
{ 
    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}

