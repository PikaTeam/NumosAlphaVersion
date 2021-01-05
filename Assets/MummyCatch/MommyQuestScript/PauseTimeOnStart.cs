using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class PauseTimeOnStart : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }
}

