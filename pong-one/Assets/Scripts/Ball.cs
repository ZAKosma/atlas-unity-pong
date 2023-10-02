using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    public float speed = 5f;

    private float screenTop = 527;
    private float screenBottom = -527;

    private Vector2 direction;

    private bool ballActive;
    
    protected RectTransform rectTransform;


    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        
        SetHeightBounds();

        direction = new Vector2(-1f, 0f).normalized;
    }

    private void Update()
    {
        if (!ballActive)
        {
            return;
        }
        Vector2 newPosition = rectTransform.anchoredPosition + (direction * speed * Time.deltaTime);
        
        rectTransform.anchoredPosition = newPosition;

        
        if (rectTransform.anchoredPosition.y > screenTop || rectTransform.anchoredPosition.y < screenBottom)
        {
            direction.y *= -1f;
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Paddle paddle = collision.gameObject.GetComponent<Paddle>();
            
            float y = BallHitPaddleWhere(GetPosition(), paddle.AnchorPos(), paddle.GetComponent<RectTransform>().sizeDelta.y / 2f);
            Vector2 newDirection = new Vector2(paddle.isLeftPaddle ? 1f : -1f, y);
            
            Reflect(newDirection);
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            // Debug.Log("pos: " + rectTransform.anchoredPosition.x);
            //Left goal
            if (this.rectTransform.anchoredPosition.x < -1)
            {
                ScoreManager.Instance.ScorePointPlayer2();
            }
            //Right goal
            else
            {
                ScoreManager.Instance.ScorePointPlayer1();
            }
        }
    }

    public void Reflect(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }

    public void SetBallActive(bool value)
    {
        ballActive = value;
    }

    public Vector2 GetPosition()
    {
        return rectTransform.anchoredPosition;
    }

    public void SetHeightBounds()
    {
        var height = UIScaler.Instance.GetUIHeightPadded();

        screenTop = height / 2;
        screenBottom = -1 * height / 2;
    }
    
    protected float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }
}