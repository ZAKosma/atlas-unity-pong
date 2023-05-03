using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Paddle : MonoBehaviour
{
    public bool isLeftPaddle = true;
    
    private float halfPlayerHeight;
    private float screenTop = 4.5f;
    private float screenBottom = -4.5f;

    private float bounceDirection = 1f;

    private void Start()
    {
        halfPlayerHeight = transform.localScale.y / 2f;

        if (isLeftPaddle)
        {
            bounceDirection = 1f;
        }
        else
        {
            bounceDirection = -1f;
        }
    }
    
    public void Move(float movement)
    {
        //Set temporary variable
        Vector2 newPosition = transform.position;
        
        //Manipulate the temporary variable
        newPosition.y += movement;
        newPosition.y = Mathf.Clamp(newPosition.y, screenBottom + halfPlayerHeight, screenTop - halfPlayerHeight);
        
        //Apply temporary variable back to original component
        transform.position = newPosition;
    }

    public void Reflect(Ball ball)
    {
        float y = BallHitPaddleWhere(ball.transform.position, transform.position, transform.localScale.y);
        ball.Reflect(new Vector2(bounceDirection, y));
    }

    private float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }
}