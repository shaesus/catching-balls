using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI _tmPro;

    private void Awake()
    {
        _tmPro = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateScoreText();
        
        GlobalEventManager.OnBallFall.AddListener(UpdateScoreText);
    }

    public void UpdateScoreText()
    {
        _tmPro.text = ScoreManager.Instance.Score.ToString();
        Debug.Log("UpdateScoreText()");
    }
}
