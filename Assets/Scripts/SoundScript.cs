using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource walk;
    public AudioSource run;
    public AudioSource attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void walkSound()
    {
        walk.Play();
    }
    void runSound()
    {
        run.Play();
    }
    void attackSound()
    {
        attack.Play();
    }

    
}
