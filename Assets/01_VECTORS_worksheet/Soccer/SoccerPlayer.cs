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

    SoccerPlayer findclosestplayerdot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;

        for (int i = 0; i < OtherPlayers.Length; i++)
        {
            Vector3 toPlayer = OtherPlayers[i].transform.position - transform.position;
            toPlayer = toPlayer.normalized;

            float dot = Vector3.Dot(transform.forward, toPlayer);
            float angle = Mathf.Acos(dot);
            angle = angle * Mathf.Rad2Deg;

            if (angle < minAngle)
            {
                minAngle = angle;
                closest = OtherPlayers[i];
            }
        }
        return closest;
    }

    void drawvectors()
    {
        foreach (SoccerPlayer other in OtherPlayers)
        {
            Debug.DrawRay(transform.position, (other.transform.position - transform.position), Color.black);
        }
    }

    //void FindMinimum()
    //{
    //    float Min = 5f;
    //    float Max = 20f;
    //    float Smallest = Min - 1f;

    //    for(int i =0; i<10; i++)
    //    {
    //        float height = Random.Range(Min,Max);
    //        Debug.Log(height);

    //        if (height < Smallest || i == 0)
    //        {
    //            Smallest = height;
    //        }
    //    }

    //    Debug.Log("smallest =" + Smallest);
    //}

    void Update()
    {
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        if (IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
        }

        drawvectors();

        SoccerPlayer targetPlayer = findclosestplayerdot();
        Debug.Log("yes" + targetPlayer);
        targetPlayer.GetComponent<Renderer>().material.color = Color.green;

        foreach (SoccerPlayer other in OtherPlayers.Where(t => t != targetPlayer))
        {
            other.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}



