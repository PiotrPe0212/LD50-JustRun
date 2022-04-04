using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreUpdate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI finalScore;
    private float playerScore;
    void Start()
    {
        
    }

 
    void Update()
    {if (GameManager.Instance.State != GameManager.GameState.PlayGame) return;
        ScoreChange();
        
    }

    public void ScoreChange()
    {
        playerScore = PlayerController.Instance.xPlayerPos;
        score.text = "SCORE: " + Mathf.RoundToInt(playerScore).ToString();
        finalScore.text = "YOUR SCORE: " + Mathf.RoundToInt(playerScore).ToString();
    }
}
