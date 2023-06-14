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

public class AIPlayer : MonoBehaviour
{
    public float speed = 5f;
    public AILevel difficulty = AILevel.Easy;

    //private Rigidbody2D rb;
    private float halfPlayerHeight;
    private Ball ball;
    
    private Paddle thisPaddle;

    private bool letsPlay;

    private void Start()
    {
        letsPlay = false;
        StartCoroutine(StartDelay());
    }

    private void Update()
    {
        if (letsPlay)
        {
            Vector2 newPosition;
            if (difficulty == AILevel.Easy)
            {
                //newPosition = rigidbody2D.position + Vector2.up * Mathf.Sign(ball.transform.position.y - transform.position.y) * speed * Time.fixedDeltaTime;
                thisPaddle.Move(Math.Sign(ball.transform.position.y - transform.position.y) * speed *
                                Time.fixedDeltaTime);

                //Change position based upon distance of the ball and likely trajectory
            }
            else if (difficulty == AILevel.Medium)
            {
                newPosition = thisPaddle.transform.position + Vector3.up * Mathf.Sign(ball.transform.position.y - transform.position.y) *
                    speed * Time.fixedDeltaTime * 1.5f;
            }
            else
            {
                newPosition = thisPaddle.transform.position + Vector3.up * Mathf.Sign(ball.transform.position.y - transform.position.y) *
                    speed * Time.fixedDeltaTime * 2f;
            }

            //newPosition.y = Mathf.Clamp(newPosition.y, -4.5f + halfPlayerHeight, 4.5f - halfPlayerHeight);
            //rigidbody2D.MovePosition(newPosition);
        }
    }

    IEnumerator StartDelay()
    {
        yield return 0;
        
        var parentObj = transform.parent;
        
        //rb = parentObj.GetComponent<Rigidbody2D>();
        halfPlayerHeight = transform.localScale.y / 2f;
        //ball = GameObject.FindWithTag("Ball");
        ball = GameManager.Instance.activeBall;
        
        thisPaddle = parentObj.GetComponent<Paddle>();
        
        // Disabling the Player script if present
        Player player = parentObj.GetComponent<Player>();
        if(player != null)
        {
            player.enabled = false;
        }

        letsPlay = true;
    }
}