using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //addforce using forcemode.impulse will add instant force impulse to the object
        rb.AddForce(force, ForceMode.Impulse);
     }

    void FixedUpdate()
    {
        //logging the ball's position
        Debug.Log(transform.position);
    }
}

