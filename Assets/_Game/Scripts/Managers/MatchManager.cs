using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MatchManager : MonoBehaviour {

    [HideInInspector]
    public int BallPocketedPlayer1;

    [HideInInspector]
    public int BallPocketedPlayer2;

    public int TotalBallsToPlayer = 4;

    [HideInInspector]
    public UnityEvent OnScore;

    [HideInInspector]
    public ScoreEvent OnWin;

    public EndGameManager EndGameManager;

    public AudioClip matchClip;

    private bool m_matchFinished = false;
    private bool m_matchStarted = false;

    void Start() {
        if (OnWin == null)
            OnWin = new ScoreEvent();
        OnWin.AddListener(WinPlayer);

        foreach (Ball ball in FindObjectsOfType<Ball>()) {
            ball.OnScore.AddListener(Score);
        }

        foreach (PlayerLife player in FindObjectsOfType<PlayerLife>()) {
            print(player.playerNumber);
            player.OnDeath.AddListener(DeathPlayer);
            player.ApplyDamage(player.TotalLife);
        }

        EndGameManager = FindObjectOfType<EndGameManager>();

        AudioManager.instance.PlayAudioClip(matchClip);
    }

    IEnumerator StartPlay() {
        yield return new WaitForSeconds(1.1f);
        foreach (PlayerLife player in FindObjectsOfType<PlayerLife>()) {
            print(player.playerNumber);
            player.OnDeath.AddListener(DeathPlayer);
            player.ApplyDamage(player.TotalLife);
        }
    }

    private void Score(int numberPlayer) {
        if (numberPlayer == 1)
            BallPocketedPlayer1++;
        else
            BallPocketedPlayer2++;

        if (OnScore != null)
            OnScore.Invoke();

        if (BallPocketedPlayer1 >= TotalBallsToPlayer || BallPocketedPlayer2 >= TotalBallsToPlayer)
            OnWin.Invoke(numberPlayer);
    }

    IEnumerator RespawnPlayer(PlayerLife player) {
        yield return new WaitForSeconds(player.TotalTimeRespawn);
        player.gameObject.SetActive(true);
        var move = player.GetComponent<MoveCharController>();
        move.ResetMovement();

        player.OnRespawn.Invoke(player);
        m_matchStarted = true;
    }

    void DeathPlayer(PlayerLife player) {
        StartCoroutine("RespawnPlayer", player);
    }

    void WinPlayer(int playerNumber) {
        print("Player " + playerNumber.ToString() + " win.");
        m_matchFinished = true;
        EndGameManager.ShowEndPanel(BallPocketedPlayer1, BallPocketedPlayer2, playerNumber);
    }

    public bool MatchFinished() {
        return m_matchFinished;
    }

    public bool MatchStarted() {
        return m_matchStarted;
    }



}
