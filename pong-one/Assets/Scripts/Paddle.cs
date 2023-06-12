using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Paddle : MonoBehaviour
{
    public bool isLeftPaddle = true;
    
    private float halfPlayerHeight;
    private float screenTop = 527;
    private float screenBottom = -527;

    private float bounceDirection = 1f;
    
    private RectTransform rectTransform;


    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        halfPlayerHeight = rectTransform.sizeDelta.y / 2f;

        var height = UIScaler.Instance.GetUIHeight();

        screenTop = height / 2;
        screenBottom = -1 * height / 2;

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
        Vector2 newPosition = rectTransform.anchoredPosition;
        
        //Manipulate the temporary variable
        newPosition.y += movement;
        newPosition.y = Mathf.Clamp(newPosition.y, screenBottom + halfPlayerHeight, screenTop - halfPlayerHeight);
        
        //Apply temporary variable back to original component
        rectTransform.anchoredPosition = newPosition;
    }

    public void Reflect(Ball ball)
    {
        float y = BallHitPaddleWhere(ball.GetPosition(), rectTransform.anchoredPosition, rectTransform.sizeDelta.y / 2f);
        //Debug.Log("X: " + bounceDirection + " Y: " + y);
        ball.Reflect(new Vector2(bounceDirection, y));
    }

    private float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }
}