using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        /*bool groundedPlayer = true;
        Vector3 playerVelocity = Vector3.zero;
        float jumpHeight = 1f;
        float jumpModifier = 1f;
        float gravityValue = -9.81f;
        
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            isJumping = true;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue); 
        }
        else if (Input.GetButton("Jump") && isJumping)
        {
            playerVelocity.y += jumpHeight * jumpModifier;
        }*/
    }

    
    /*bool isJumping = false;
    
    IEnumerator JumpTimer()
    {
        yield return new WaitForSeconds(1);
        isJumping = false;
    }*/

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
                
            }
            //Right goal
            else
            {
                
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