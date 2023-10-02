using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    private GameStats _gameStats;
    private void Start()
    {
        _gameStats = FindObjectOfType<GameStats>();
        _gameStats.onScoreChanged.AddListener(AddScore);
        if(_gameStats.IsUnityNull()) throw new Exception("GameStatsManager is null");
    }

    public void AddScore()
    {
        scoreText.text = _gameStats.Score.ToString();
    }
}
