using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime;

        float dx = velocity.x * dt;
        float dy = velocity.y * dt;
        float dz = velocity.z * dt;

        transform.Translate(new Vector3(dx,dy,dz));
    }
}