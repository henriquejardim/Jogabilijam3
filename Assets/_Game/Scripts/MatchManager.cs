using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {

    // Use this for initialization
    int BallPocketedPlayer1;
    int BallPocketedPlayer2;

    public int TotalBallsToPlayer = 4;

    public ScoreEvent OnWin;
	void Start () {
        if (OnWin == null)
            OnWin = new ScoreEvent();
        OnWin.AddListener(WinPlayer);

        foreach (Ball ball in FindObjectsOfType<Ball>())
        {
            ball.OnScore.AddListener(Score);
        }

        foreach (PlayerLife player in FindObjectsOfType<PlayerLife>())
        {
            player.OnDeath.AddListener(DeathPlayer);
        }       		
	}

    private void Score(int numberPlayer)
    {
        if (numberPlayer == 1)
            BallPocketedPlayer1++;
        else
            BallPocketedPlayer2++;

        if (BallPocketedPlayer1 >= TotalBallsToPlayer || BallPocketedPlayer2 >= TotalBallsToPlayer)
            OnWin.Invoke(numberPlayer);
    }

    IEnumerator RespawnPlayer(PlayerLife player)
    {
        yield return new WaitForSeconds(player.TotalTimeRespawn);
        player.gameObject.SetActive(true);
        var move = player.GetComponent<MoveCharController>();
        move.ResetMovement();

        player.OnRespawn.Invoke(player);
    }

    void DeathPlayer(PlayerLife player)
    {
        StartCoroutine("RespawnPlayer",player);
    }

    void WinPlayer(int numberPlayer)
    {
        print("Player " + numberPlayer.ToString() + " win.");
    }

}
