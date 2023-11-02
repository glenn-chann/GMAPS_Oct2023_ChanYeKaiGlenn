using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f, jumpPower = 0.1f;
    public SpriteRenderer sprite;

    Rigidbody2D body;
    bool isGrounded;
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get the player's horizontal input 
        horizontal = Input.GetAxisRaw("Horizontal");

        //if the player pressed jump and isGrounded 
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            //add a impulse force to allow the character to jump
            body.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        //move the character based on the player's input 
       body.AddForce(transform.right * horizontal * moveSpeed);
    }

    
    void OnTriggerStay2D(Collider2D obj)
    {
        //if the character is in a planet's atmosphere 
        if (obj.CompareTag("Planet"))
        {
            //add drag 
            body.drag = 1f;

            //get distance between planet and player 
            float distance = Mathf.Abs(obj.GetComponent<GravityPoint>().planetRadius - Vector2.Distance(transform.position, obj.transform.position));

            //if the distance is less then 2f then the player is grounded 
            if (distance < 2f)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false; 
            }
        }
    }

    //when the player exits a planet's atmosphere set the drag to 0.2 
    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Planet"))
        {
            body.drag = 0.2f;
        }
    }
}
