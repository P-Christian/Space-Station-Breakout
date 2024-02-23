using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoScript : MonoBehaviour
{
    [SerializeField]
    VideoPlayer myVideoPlayer;
    public string targetSceneName;

    private void Awake()
    {
        myVideoPlayer = GetComponent<VideoPlayer>();
        myVideoPlayer.Play();
        myVideoPlayer.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(targetSceneName);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            myVideoPlayer.Stop();
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
