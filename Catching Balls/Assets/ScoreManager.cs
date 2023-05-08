using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } = null;

    public Animator animator;
    
    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Score = 0;
        
        GlobalEventManager.OnBallFall.AddListener(DecrementScore);
    }
    
    public void IncrementScore()
    {
        Score++;
        animator.SetTrigger("Bloop");
    }

    private void DecrementScore()
    {
        Score--;
        Debug.Log("DecrementScore()");
    }
}
