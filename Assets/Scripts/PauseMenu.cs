using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePause = false;

    public GameObject pauseMenuUI;
    public GameObject instructionsOne;
    public GameObject instructionsTwo;

    public string sceneName;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            if (isGamePause)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePause = true;
        instructionsOne.gameObject.SetActive(false);
        instructionsTwo.gameObject.SetActive(false);
    }

    public void LoadingMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
        PlayerPrefs.DeleteAll();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
