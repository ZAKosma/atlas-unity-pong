using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    public float speed = 5f;

    public float screenTop = 4.5f;
    public float screenBottom = 4.5f;

    private Vector2 direction;

    private bool ballActive;

    private void Start()
    {
        direction = new Vector2(-1f, 0f);
    }

    private void Update()
    {
        if (!ballActive)
        {
            return;
        }
        Vector2 newPosition = new Vector2(transform.position.x, transform.position.y) + (direction * speed * Time.deltaTime);
        
        transform.position = newPosition;
        
        if (transform.position.x > 9f || transform.position.x < -9f)
        {
            direction.x *= -1f;
        }

        if (transform.position.y > screenTop || transform.position.y < screenBottom)
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
            if (this.gameObject.transform.position.x < -1)
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
}