using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
using System.Text;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
        if (IsCaptain)
        {
            //FindMinimum();
            //put the players on the field to the OtherPlayers array 
            OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray();
        }
    }


    //float magnitude(vector3 vector)
    //{

    //}

    //vector3 normalise(vector3 vector)
    //{

    //}

    //float dot(vector3 vectora, vector3 vectorb)
    //{

    //}

    //function to find the closet players
    SoccerPlayer findclosestplayerdot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;

        //for the length of the OtherPlayers' array 
        for (int i = 0; i < OtherPlayers.Length; i++)
        {
            //get the vector of the captain to the player and set it as the toPlayer variable 
            Vector3 toPlayer = OtherPlayers[i].transform.position - transform.position;
            //normalise the toPlayer vector 
            toPlayer = toPlayer.normalized;

            //get the dotproduct between the captains forward vector and the toplayer vector 
            float dot = Vector3.Dot(transform.forward, toPlayer);
            //get the angle between the 2 vectors using the dot product and the arc cosine 
            float angle = Mathf.Acos(dot);
            //change the results to Deg because Acos returns the results in radians 
            angle = angle * Mathf.Rad2Deg;

            //if the new angle is smaller then the previous smallest angle 
            if (angle < minAngle)
            {
                //set the new angle to the minAngle 
                minAngle = angle;
                //set the new player to the new closest player 
                closest = OtherPlayers[i];
            }
        }
        //return the closets angle 
        return closest;
    }

    //drawvector function 
    void drawvectors()
    {
        //foreach player in the OtherPlayers array 
        foreach (SoccerPlayer other in OtherPlayers)
        {
            //draw a ray from the captain to the player 
            Debug.DrawRay(transform.position, (other.transform.position - transform.position), Color.black);
        }
    }

    //void FindMinimum()
    //{
    //    float Min = 5f;
    //    float Max = 20f;
    //    float Smallest = Min - 1f;
            
          //create a loop that loops 10 times 
    //    for(int i =0; i<10; i++)
    //    {
              //set the height variable to a random values between the min and max range 
    //        float height = Random.Range(Min,Max);
    //        Debug.Log(height);
              
              //if the height is smaller then the old smallest value 
    //        if (height < Smallest || i == 0)
    //        {
                  //set the smallest variable as the height 
    //            Smallest = height;
    //        }
    //    }
          
          //debug to show the smallest value out of the 10
    //    Debug.Log("smallest =" + Smallest);
    //}

    void Update()
    {
        //drawing the forward vector 
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        //if the object is the captain 
        if (IsCaptain)
        {
            //code to rotate the direction the captain is facing 
            //angle is the player input multiplied by the rotation speed 
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
        }

        drawvectors();

        //target player is set the the return value of the findclosestplayerdot function
        SoccerPlayer targetPlayer = findclosestplayerdot();
        //set the closest player to green 
        targetPlayer.GetComponent<Renderer>().material.color = Color.green;

        //set the rest of the players to white
        foreach (SoccerPlayer other in OtherPlayers.Where(t => t != targetPlayer))
        {
            other.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}



