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

    //when an obj enters the planet's atmosphere 
    void OnTriggerStay2D(Collider2D obj)
    {
        //set gravitationalPower to the gravityScale 
        float gravitationalPower = gravityScale;
        //get the distance between the object in the planet's atomsphere and the planet and set it to dist variable 
        float dist = Vector2.Distance(obj.transform.position, transform.position);

        //if the dist is less than the planetradius + the minimum gravity range 
        if(dist>(planetRadius + gravityMinRange))
        {
            //set min to the planetRadius + minimum gravity range 
            float min = planetRadius + gravityMinRange;
            //calculate the amount of gravitational power depending on how close the obj is to the planet 
            gravitationalPower = (((min + gravityMaxRange) - dist) / gravityMaxRange) * gravitationalPower;
        }

        //get direction to move the player by multiplying the vector of planet to the player by the gravityscale 
        Vector2 dir = (transform.position - obj.transform.position) * gravityScale;
        //add the force to the player to move the player to the planet like gravity 
        obj.GetComponent<Rigidbody2D>().AddForce(dir);

        //if the obj that enters the planet's atmosphere is a player 
        if (obj.CompareTag("Player"))
        {
            //rotating the player so they will appear standing on the planet's surface.
            obj.transform.up = Vector2.MoveTowards(obj.transform.up, -dir, gravityScale * Time.deltaTime);
        }
    }
}
