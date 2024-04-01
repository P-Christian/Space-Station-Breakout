using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public GameObject DeathScreen;
    public void gameOver()
    {
        Time.timeScale = 0f;
        DeathScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        StaticData.valueToKeep = "0";
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("GameScene");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.DeleteAll();
    }
}
