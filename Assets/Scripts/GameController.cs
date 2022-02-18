using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Starter starter;

    public GameObject ball;

    public Text scoreTextRight;
    public Text scoreTextLeft;

    private bool started = false;

    private int scoreLeft = 0;
    private int scoreRight = 0;

    private BallController ballController;

    private Vector3 startingPosition;
    
    void Start()
    {
        ballController = ball.GetComponent<BallController>();
        startingPosition = ball.transform.position;
    }

    
    void Update()
    {
        if(started)
            return;

        if (Input.GetKey(KeyCode.Space))
        {
            started = true;
            starter.StartCountdown();
        }
    }

    public void ScoreGoalLeft()
    {
        scoreLeft += 1;
        UpdateUI();
        Resetball();
    }

    public void ScoreGoalRight()
    {
        scoreRight += 1;
        UpdateUI();
        Resetball();
    }

    private void UpdateUI()
    {
        scoreTextLeft.text = scoreLeft.ToString();
        scoreTextRight.text = scoreRight.ToString();
    }

    private void Resetball()
    {
        ballController.Stop();
        ball.transform.position = startingPosition;
        starter.StartCountdown();
    }

    public void StartGame()
    {
        ballController.Go();
    }
    
}
