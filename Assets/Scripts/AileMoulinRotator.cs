using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AileMoulinRotator : MonoBehaviour
{
    public float smoothRotation = 5.0f;

    void Update()
    {
        transform.Rotate(-Vector3.right * Time.deltaTime * smoothRotation);
    }
}
