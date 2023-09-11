using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Adjust this to control the rotation speed.

    void Update()
    {
        // Rotate the object around its up (Y) axis.
        transform.Rotate(0f,0f,.5f);
    }
}
