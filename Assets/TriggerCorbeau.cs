using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TriggerCorbeau : MonoBehaviour
{
	public Animator anim;

	public AudioSource crowScreamSource;
	public AudioSource wingsSource;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{

            if (crowScreamSource != null && wingsSource != null)
            {
				if (!wingsSource.isPlaying)
				{
					wingsSource.Play();
				}
				if (!crowScreamSource.isPlaying)
				{
					crowScreamSource.Play();
				}
			}

			anim.SetTrigger("Fly");
		}
	} 

}
