using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        //if we hold the mouse button 
        if (Input.GetMouseButtonDown(0))
        {
            var startLinePos = Camera.main.ScreenToWorldPoint (Input.mousePosition); // Start line drawing
            //check if the mouse cursor is on the ball 
            if(ball != null && ball.IsCollidingWith(startLinePos.x,startLinePos.y))
            {
                //draw a line from the ball to the mouse 
                drawnLine = lineFactory.GetLine(ball.Position.ToUnityVector2(),startLinePos, 1f, Color.black);
                drawnLine.EnableDrawing(true);
            }
        }
        //if we let go of the mouse button
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            //disable the line
            drawnLine.EnableDrawing(false);

            //set the ball's velocity to the vector of the line we drew
            HVector2D v = new HVector2D((drawnLine.start - drawnLine.end));
            ball.Velocity = v;

            drawnLine = null; // End line drawing            
        }

        //if drawnline is not empty 
        if (drawnLine != null)
        {
            //set the end of the drawnline to the mouse cursor 
            drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    public void Clear()
    {
        var activeLines = lineFactory.GetActive();

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false);
        }
    }
}
