using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    void FixedUpdate()
    {
        //calculate the vector that represents the moon's gravity 
        gravityDir = planet.transform.position - transform.position;
        //calculate the move vector for the astronaut 
        moveDir = new Vector3(gravityDir.y, - gravityDir.x, 0f);
        //flip the normalised vector 
        moveDir = moveDir.normalized * -1f;

        //add force to move the astronaut in the moveDir 
        rb.AddForce(moveDir * force);

        //get the gravity vector normalised 
        gravityNorm = gravityDir.normalized;

        //multiply gravityNoram by gravityStrength in the add force function to get gravity 
        rb.AddForce(gravityNorm * gravityStrength);

        //get the angle to rotate the mario sprite 
        float angle = Vector3.SignedAngle(-Vector3.up,gravityNorm,Vector3.forward);

        //rotate the mario sprite 
        rb.MoveRotation(Quaternion.Euler(0,0,angle));

        //draw the arrows of the vectors 
        DebugExtension.DebugArrow(transform.position, gravityDir, Color.red);
        DebugExtension.DebugArrow(transform.position, moveDir, Color.blue);
    }
}


