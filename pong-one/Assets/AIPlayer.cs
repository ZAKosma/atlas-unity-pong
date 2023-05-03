using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AILevel
{
    Easy,
    Medium,
    Hard
}

[RequireComponent(typeof(Paddle))]
public class AIPlayer : MonoBehaviour
{
    public float speed = 5f;
    public AILevel difficulty = AILevel.Easy;

    private Rigidbody2D rigidbody2D;
    private float halfPlayerHeight;
    private GameObject ball;
    
    private Paddle thisPaddle;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        halfPlayerHeight = transform.localScale.y / 2f;
        ball = GameObject.FindWithTag("Ball");
        
        thisPaddle = GetComponent<Paddle>();
    }

    private void Update()
    {
        Vector2 newPosition;
        if (difficulty == AILevel.Easy)
        {
            //newPosition = rigidbody2D.position + Vector2.up * Mathf.Sign(ball.transform.position.y - transform.position.y) * speed * Time.fixedDeltaTime;
            thisPaddle.Move(Math.Sign(ball.transform.position.y - transform.position.y) * speed * Time.fixedDeltaTime);
            
            //Change position based upon distance of the ball and likely trajectory
        }
        else if (difficulty == AILevel.Medium)
        {
            newPosition = rigidbody2D.position + Vector2.up * Mathf.Sign(ball.transform.position.y - transform.position.y) * speed * Time.fixedDeltaTime * 1.5f;
        }
        else
        {
            newPosition = rigidbody2D.position + Vector2.up * Mathf.Sign(ball.transform.position.y - transform.position.y) * speed * Time.fixedDeltaTime * 2f;
        }

        //newPosition.y = Mathf.Clamp(newPosition.y, -4.5f + halfPlayerHeight, 4.5f - halfPlayerHeight);
        //rigidbody2D.MovePosition(newPosition);
    }
}