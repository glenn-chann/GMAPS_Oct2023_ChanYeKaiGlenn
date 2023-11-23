using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    //function to check if mouse is colliding with the cue ball
    public bool IsCollidingWith(float x, float y)
    {
        float distance = Util.FindDistance(Position, new HVector2D(x,y));
        return distance <= Radius;
    }

    //function to check if cue ball is collider with other balls
    public bool IsCollidingWith(Ball2D other)
    {
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    //function to update the ball's position 
    private void UpdateBall2DPhysics(float deltaTime)
    {
        //getting the displacement by using velocity over time 
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;

        //setting the position varible to be the displacement 
        Position.x += displacementX;
        Position.y += displacementY;

        //moving the ball by setting its position to position.x and position.y
        transform.position = new Vector2(Position.x, Position.y);
    }
}

