using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : Singleton<VibrationManager>
{
    private void Start()
    {
        Vibration.Init();
    }

    public void Pop()
    {
        Vibration.VibratePop();
    }
}
