using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    public TMP_InputField userName;
    // Start is called before the first frame update
    public void SavedUserInput()
    {
        string userInput = userName.text;
        PlayerPrefs.SetString("UserInput", userInput);
        PlayerPrefs.Save();

    }
    public void LoadUserInput()
    {
        string userInput = PlayerPrefs.GetString("UserInput", "");
        userName.text = userInput;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
