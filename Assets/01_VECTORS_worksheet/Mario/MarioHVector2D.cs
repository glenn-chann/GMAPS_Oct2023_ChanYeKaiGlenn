using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //calculate the vector that represents the moon's gravity
        gravityDir = new HVector2D(planet.position - transform.position);  
        //calculate the move vector for the astronaut 
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);
        //flip the normalised vector 
        moveDir = moveDir.Normalize() * -1f;

        //multiply the moveDir by force in the add force function to move the character 
        rb.AddForce(moveDir.ToUnityVector3() * force);

        //get the gravity vector normalised 
        gravityNorm = gravityDir.Normalize();

        //mulitply gravityNorm by gravityStrength in the add force function to get gravity 
        rb.AddForce(gravityNorm.ToUnityVector3() * gravityStrength);

        //get the angle to rotate the mario sprite 
        float angle = Vector3.SignedAngle(-Vector3.up, gravityNorm.ToUnityVector3(), Vector3.forward);

        //rotate the mario sprite 
        rb.MoveRotation(Quaternion.Euler(0, 0, angle));

        //draw the arrows of the vectors 
        DebugExtension.DebugArrow(transform.position, gravityDir.ToUnityVector3(), Color.red);
        DebugExtension.DebugArrow(transform.position, moveDir.ToUnityVector3(), Color.blue);

    }
}
