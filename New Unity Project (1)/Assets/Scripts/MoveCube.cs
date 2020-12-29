using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float forceX = 0f;
    public float forceY = 0f;
    public float forceZ = 0f;

    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {

        
            rb.AddForce(forceX, forceY, forceZ, ForceMode.Force);
    }
}
