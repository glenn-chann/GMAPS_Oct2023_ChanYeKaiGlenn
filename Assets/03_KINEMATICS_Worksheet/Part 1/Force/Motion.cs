using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    //adding a public velocity varible to change in the inspector
    public Vector3 velocity;

    void FixedUpdate()
    {
        //creating a deltatime varible for easier access
        float dt = Time.deltaTime;

        //multiplying the veolcity varible by deltatime to have consistent movement regardless of framerate
        float dx = velocity.x * dt;
        float dy = velocity.y * dt;
        float dz = velocity.z * dt;

        //moving the ball using transform.translate and the velocity*deltatime as a vector3 
        transform.Translate(new Vector3(dx,dy,dz));
    }
}