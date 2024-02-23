using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInv : MonoBehaviour
{
    public int NumOfComponents { get; private set; }
    
    public UnityEvent<PlayerInv> OnComponentsCollected;
     
    public void ComponentsCollected () {
        NumOfComponents = Convert.ToInt32(StaticData.valueToKeep);
        NumOfComponents++;
        OnComponentsCollected.Invoke (this);

        if (NumOfComponents == 8)
        {
            Debug.Log("Mission Completed");
        }
    }
}
