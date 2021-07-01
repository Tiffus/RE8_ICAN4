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
        if (fps_Controller.isRunning )
        {
            //Debug.Log("Run");
            if (!runSource.isPlaying)
            {
                runSource.Play();
            }
            walkSource.Stop();
        }
        else if (fps_Controller.moveDirection.x!= 0 && fps_Controller.moveDirection.z != 0)
        {
            //Debug.Log("walk");
            if(!walkSource.isPlaying)
            {
                walkSource.Play();
            }
            runSource.Stop();
        }
        else
        {
            //Debug.Log("idle");
            runSource.Stop();
            walkSource.Stop();
        }
    }
}
