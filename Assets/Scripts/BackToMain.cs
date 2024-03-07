using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public string targetSceneName;

    private void Start()
    {
        Cursor.visible = true;
    }
    public void Back()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
