using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    bool gameHasEnded = false;
    public float restartDelay = 1;
    GameObject slowTimer;

    private void Start()
    {
        slowTimer = GameObject.FindGameObjectWithTag("SlowUI");
        slowTimer.SetActive(false);
    }
    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            StaticData.valueToKeep = "0";
            PlayerPrefs.DeleteAll();
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        
    }
}
