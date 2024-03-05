using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GiveValue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI componentText;

    public void Start()
    {
        string newText = StaticData.valueToKeep;
        if (newText == "0")
        {
            componentText.text = "Collected Components: 0/10";
        }
        else
        {
            componentText.text = "Collected Components: " + newText + "/10";
        }
        
    }
}
