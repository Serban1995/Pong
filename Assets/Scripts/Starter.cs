using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    private GameController gameController;
    private Animator anim;
    
   
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        anim = GetComponent<Animator>();
    }

    public void StartCountdown()
    {
        anim.SetTrigger("StartCountdown");
    }

    public void StartGame()
    {
        gameController.StartGame();
    }

    
  
}
