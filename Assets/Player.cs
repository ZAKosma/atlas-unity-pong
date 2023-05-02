using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Paddle))]
public class Player : MonoBehaviour
{
    public float speed = 5f;

    private Paddle thisPaddle;

    private void Start()
    {
        thisPaddle = GetComponent<Paddle>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        thisPaddle.Move(verticalInput * speed * Time.deltaTime);
    }
}