using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TriggerCorbeau : MonoBehaviour
{
	public Animator anim;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			anim.SetTrigger("Fly");
		}
	}

}
