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
        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray();
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
       
    }

    void drawvectors()
    {
        foreach (SoccerPlayer other in OtherPlayers)
        {
            for (int i = 0; i <= OtherPlayers.Length - 1; i++)
            {
                if (OtherPlayers[i].gameObject.name == "Captain")
                {
                    return;
                }
                else
                { 
                    SoccerPlayer player = OtherPlayers[i];
                    Debug.DrawLine(player.transform.position, other.transform.position);
                }
            }
        }
    }

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
    }
}


