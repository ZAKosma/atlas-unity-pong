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
    
    private RectTransform rectTransform;


    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        
        SetHeightBounds();

        direction = new Vector2(-1f, 0f);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            collision.gameObject.GetComponent<Paddle>().Reflect(this);
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            //Left goal
            if (this.rectTransform.position.x < -1)
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
        direction = newDirection;
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
}