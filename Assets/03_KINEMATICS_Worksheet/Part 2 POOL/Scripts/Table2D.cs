using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table2D : MonoBehaviour
{
    public List<Ball2D> balls;
    Ball2D ball;

    private void Start()
    {
        
    }

    //function to check if given ball is colliding with any other ball in the balls list
    bool CheckBallCollision(Ball2D toCheck)
    {
        //for everyball in balls list
        for (int i = 0; i < balls.Count; i++)
        {
            ball = balls[i];
            //if current ball in list is colliding with ball to check and they are not the same ball
            if (ball.IsCollidingWith(toCheck) && toCheck != ball)
            {
                //return true
                Debug.Log(true);
                return true;
            }
        }
        //return false
        return false;
    }

    private void FixedUpdate()
    {
        //if checkballcollision returns true
        if (CheckBallCollision(balls[0]))
        {
            //print collision to console
            Debug.Log("COLLISION!");
        }
    }
}
