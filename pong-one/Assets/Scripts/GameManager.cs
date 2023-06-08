using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Game variables
    [SerializeField] private float startDelay = 3f;
    // private int leftScore = 0;
    // private int rightScore = 0;
    // [SerializeField]
    // private int scoreToWin = 11;
    
    //Set Up variables
    [SerializeField]
    private GameObject ballPrefab;

    private Ball activeBall;
    
    //Singleton Pattern
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void SetGame()
    {
        // leftScore = 0;
        // rightScore = 0;
        
        activeBall = Instantiate(ballPrefab, Vector3.zero, this.transform.rotation).GetComponent<Ball>();
        activeBall.SetBallActive(false);
    }

    void StartGame()
    {
        Debug.Log("Starting game!");
        activeBall.SetBallActive(true);
    }

    private void Start()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        SetGame();
        yield return new WaitForSeconds(startDelay);
        StartGame();
    }
}
