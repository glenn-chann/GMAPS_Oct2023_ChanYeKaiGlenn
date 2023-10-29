using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class GravityPoint : MonoBehaviour
{
    public float gravityScale = 12f, planetRadius = 2f, gravityMinRange = 2f, gravityMaxRange = 4f;
    

    // Start is called before the first frame update
    void Update()
    {
       
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        float gravitationalPower = gravityScale;
        float dist = Vector2.Distance(obj.transform.position, transform.position);

        if(dist>(planetRadius + gravityMinRange))
        {
            float min = planetRadius + gravityMinRange;
            gravitationalPower = (((min + gravityMaxRange) - dist) / gravityMaxRange) * gravitationalPower;
        }

        Vector2 dir = (transform.position - obj.transform.position) * gravityScale;
        obj.GetComponent<Rigidbody2D>().AddForce(dir);

        if (obj.CompareTag("Player"))
        {
            obj.transform.up = Vector2.MoveTowards(obj.transform.up, -dir, gravityScale * Time.deltaTime);
        }
    }
}
