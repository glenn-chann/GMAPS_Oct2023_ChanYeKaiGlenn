using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

namespace pool
{
    public class PongBall : MonoBehaviour
    {
        // Note that the ball can have different X and Y speeds. 
        //
        public float speedX = 4.0f;
        public float speedY = 2.0f;

        // The ball is actually a square Sprite with the image of a circle.
        // ballTop, etc., are declared to make the HandleBoundaryCollision
        // code more intuitive (we think in terms of the top, bottom, left
        // and right of a ball, rather than as offsets from its centre).
        //
        private float radius, ballTop, ballBottom, ballLeft, ballRight;

        // We could have these as public properties in the Inspector, but 
        // they are not used in any other classes, so keep them private &
        // obtain refernces to the game objects in Start().
        //
        private GameObject leftWall, rightWall, topWall, bottomWall;

        // wallOffset is the distance from the center of a wall to its inner edge 
        // (that the ball collides with). The height of the horizontal (top/bottom)
        // walls is the same as the width of the vertical (left/right) walls.
        //
        // wallOffset is used is to stop the ball from penetrating the walls (see 
        // your lecture slides).
        //
        float wallOffset;

        // References to the paddles, needed to check for collisions with
        // each paddle, in HandlePaddleCollision().
        //
        private GameObject leftPaddle, rightPaddle;
        private float paddleHeight, paddleWidth;

        // Just for debugging, to draw a line to show the ball's path.
        // Used in FixedUpdate().
        //
        private Vector3 lastpos;

        void Start()
        {
            // https://stackoverflow.com/questions/23535304/getting-the-width-of-a-sprite
            //
            radius = GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2f;

            leftWall = GameObject.Find("LeftWall");
            rightWall = GameObject.Find("RightWall");
            topWall = GameObject.Find("TopWall");
            bottomWall = GameObject.Find("BottomWall");

            wallOffset = topWall.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2f;

            leftPaddle = GameObject.Find("LeftPaddle");
            rightPaddle = GameObject.Find("RightPaddle");

            paddleHeight = leftPaddle.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
            paddleWidth = leftPaddle.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

            lastpos = transform.position;
        }

        void HandleBoundaryCollision()
        {
            float xpos, ypos;
            //if the ball's position is past the positions of the right or left wall
            //with account to the walloffset and radius of the ball. meaning if the ball has
            //collided with the left or right wall.
            if (transform.position.x < leftWall.transform.position.x + wallOffset + radius
                || transform.position.x > rightWall.transform.position.x - wallOffset - radius)
            {
                //if the ball is travelling to the right
                if (speedX > 0f)
                {
                    //set xpos to the right wall's x position - walloffset - radius
                    //this will give us the xpos of the ball as if it stopped right 
                    //as it hit the wall
                    xpos = rightWall.transform.position.x - wallOffset - radius;
                }
                //if the ball is travelling to the left
                else
                {
                    //set xpos to the left wall's x position - walloffset - radius
                    //this will give us the xpos of the ball as if it stopped right 
                    //as it hit the wall
                    xpos = leftWall.transform.position.x + wallOffset + radius;
                }
                //move the ball back to the position where it collided with the wall
                transform.position = new Vector3(xpos,
                                                 transform.position.y,
                                                 transform.position.z);
                
                //reverse the speed to send the ball back in the opposite direction.
                speedX = -speedX;
            }
            //if the ball's position is past the positions of the top or bottom wall
            //with account to the walloffset and radius of the ball. meaning if the ball has
            //collided with the top or bottom wall.
            if (transform.position.y < bottomWall.transform.position.y + wallOffset + radius
                || transform.position.y > topWall.transform.position.y - wallOffset - radius)
            {
                //if ball was travelling up
                if (speedY > 0f)
                {
                    //set ypos to the top wall's y position - walloffset - radius
                    //this will give us the ypos of the ball as if it stopped right 
                    //as it hit the wall
                    ypos = topWall.transform.position.y - wallOffset - radius;
                }
                else
                {
                    //set ypos to the bottom wall's y position - walloffset - radius
                    //this will give us the ypos of the ball as if it stopped right 
                    //as it hit the wall
                    ypos = bottomWall.transform.position.y + wallOffset + radius;
                }
                //move the ball back to the position where it collided with the wall
                transform.position = new Vector3(transform.position.x,
                                                 ypos,
                                                 transform.position.z);

                //reverse the speed to send the ball back in the opposite direction
                speedY = -speedY;
            }
        }

        void HandlePaddleCollision()
        {
            if (transform.position.x < leftPaddle.transform.position.x + paddleWidth / 2
               && transform.position.y < leftPaddle.transform.position.y + paddleHeight / 2
               && transform.position.y > leftPaddle.transform.position.y - paddleHeight / 2)
            {
                transform.position = new Vector3(leftPaddle.transform.position.x + paddleWidth / 2f + radius,
                                                 transform.position.y,
                                                 transform.position.z);
                speedX = -speedX;
            }
            // ball right is greater than paddle left
            if (transform.position.x + radius > rightPaddle.transform.position.x - paddleWidth / 2f
                // bottom of ball is less than paddle top
                && transform.position.y - radius < rightPaddle.transform.position.y + paddleHeight / 2f
                // top of ball is greater than paddle bottom
                && transform.position.y + radius > rightPaddle.transform.position.y - paddleHeight / 2f)
            {
                transform.position = new Vector3(rightPaddle.transform.position.x - (paddleWidth / 2f) - radius,
                                                 transform.position.y,
                                                 transform.position.z);
                speedX = -speedX;
            }
        }

        void FixedUpdate()
        {   
            // Move this to the top of FixedUpdate and see what happens
            ballTop = transform.position.y + radius;
            ballBottom = transform.position.y - radius;
            ballLeft = transform.position.x - radius;
            ballRight = transform.position.x + radius;
            // 

            Debug.DrawLine(lastpos, transform.position, Color.red, 5f);
            lastpos = transform.position;

            transform.Translate(new Vector2(speedX * Time.deltaTime,
                                            speedY * Time.deltaTime));

            

            HandleBoundaryCollision();
            HandlePaddleCollision();
        }
    }
}

