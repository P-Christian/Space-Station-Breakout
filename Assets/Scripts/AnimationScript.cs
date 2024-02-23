using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimationScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnAnimationFinished()
    {
        // Load the next scene when the animation is finished.
        SceneManager.LoadScene("Victory");
    }
}
