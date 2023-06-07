using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Paddle))]
public class Player : MonoBehaviour
{

    public KeyCode upKey;
    public KeyCode downKey;
    
    public float speed = 5f;

    private Paddle thisPaddle;

    private void Start()
    {
        thisPaddle = GetComponent<Paddle>();
    }

    private void Update()
    {
        float verticalInput = 0;
        if (Input.GetKey(upKey))
        {
            verticalInput = 1;
        }
        else if (Input.GetKey(downKey))
        {
            verticalInput = -1;
        }
        
        thisPaddle.Move(verticalInput * speed * Time.deltaTime);
    }
}