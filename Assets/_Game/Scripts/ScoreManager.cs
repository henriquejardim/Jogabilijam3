using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public MatchManager match;

    public Text scorePlayer1;
    public Text scorePlayer2;
    public GameObject scorePanel;
     
    void Start () {
        match.OnWin.AddListener((i) => scorePanel.SetActive(false));
        match.OnScore.AddListener(() => {
            scorePlayer1.text = match.BallPocketedPlayer1.ToString();
            scorePlayer2.text = match.BallPocketedPlayer2.ToString();
        });
       
	}

    public void SetValues (int playerOneScore, int playerTwoScore) {
        scorePlayer1.text = match.BallPocketedPlayer1.ToString();
        scorePlayer2.text = match.BallPocketedPlayer2.ToString();
    }

    
}
