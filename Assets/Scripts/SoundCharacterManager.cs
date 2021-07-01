using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCharacterManager : MonoBehaviour
{
    public AudioSource walkSource;
    public AudioSource runSource;

    public FPS_Controller fps_Controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fps_Controller.isRunning && !runSource.enabled)
        {
            runSource.Play();
            walkSource.Pause();
        }
        else if (fps_Controller.moveDirection != Vector3.zero )
        {
            walkSource.Play();
            runSource.Pause();
        }
        else
        {
            runSource.Pause();
            walkSource.Pause();
        }
    }
}
