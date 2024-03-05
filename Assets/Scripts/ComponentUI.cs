using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComponentUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI componentText;

    private PlayerInv playerInventory;
    void Start()
    {
        componentText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateComponentText(PlayerInv playerInventory)
    {
        componentText.text = playerInventory.NumOfComponents.ToString();
        string dataToKeep = componentText.text;
        StaticData.valueToKeep = dataToKeep;
        if (dataToKeep == "0" )
        {
            componentText.text = "Collected Components: 0/10";
        } else
        {
            componentText.text = "Collected Components: " + dataToKeep + "/10";
        }

        if (playerInventory != null && playerInventory.NumOfComponents == 10)
        {
            componentText.text = "Go to 1st Floor and Escape the ship";
        }
    }
}
