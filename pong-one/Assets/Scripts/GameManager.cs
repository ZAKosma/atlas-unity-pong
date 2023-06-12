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

    [SerializeField] private GameObject canvasParent;

    private Ball activeBall;
    
    //Singleton Pattern
    public static GameManager Instance { get; private set; }

    private Goal[] goals;

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

        goals = new Goal[2];
    }

    void SetGame()
    {
        // leftScore = 0;
        // rightScore = 0;
        
        activeBall = Instantiate(ballPrefab, Vector3.zero, this.transform.rotation, canvasParent.transform).GetComponent<Ball>();
        activeBall.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
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
        
        SetBounds();
        
        StartGame();
    }

    void SetBounds()
    {
        
        activeBall.SetHeightBounds();
        foreach (var g in goals)
        {
            g.SetHeightBounds();
        }
    }

    public void ResetBall()
    {
        //Debug.Log("Restting");
        StartCoroutine(ResetBallCoroutine());
    }    
    private IEnumerator ResetBallCoroutine()
    {
        GameObject.Destroy(activeBall.gameObject);
        
        //wait till next frame for ball to destroy
        yield return null;
        
        StartCoroutine(StartTimer());
    }

    public void SetGoalObj(Goal g)
    {
        if (goals[0])
        {
            goals[1] = g;
        }
        else
        {
            goals[0] = g;
        }
    }
}
