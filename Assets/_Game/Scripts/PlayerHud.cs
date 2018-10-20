using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{

    public PlayerHudInformation PlayerInfo;
    public Image[] LifeCell = new Image[5];
    public Image[] BallSlots = new Image[4];
    public Image PlayerColor;

    int score;
    int damageRecived;
    float timeRespawn;
    bool isDeath;
    // Use this for initialization
    void Start()
    {
        foreach (var ball in FindObjectsOfType<Ball>())
        {
            if (ball.PlayerNumber == PlayerInfo.PlayerNumber)
                ball.OnScore.AddListener(Score);
        }
        foreach (var player in FindObjectsOfType<PlayerLife>())
        {
            player.OnDamage.AddListener(Damage);
            player.OnRespawn.AddListener(Respawn);
            player.OnDeath.AddListener(Death);
        }
        PlayerColor.color = PlayerInfo.PlayerColor;
        for (int i = 0; i < BallSlots.Length; i++)
        {
            BallSlots[i].sprite = PlayerInfo.BallInactive;
        }
        FullLifeBar();
    }

    private void FullLifeBar()
    {
        for (int i = 0; i < LifeCell.Length; i++)
        {
            LifeCell[i].color = PlayerInfo.LifeCellColor;
            LifeCell[i].fillAmount = 1;
        }
        damageRecived = 0;
    }
    private void ClearLifeBar()
    {
        for (int i = 0; i < LifeCell.Length; i++)
        {
            LifeCell[i].fillAmount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Score(int playerNumber)
    {
        if (playerNumber == PlayerInfo.PlayerNumber)
        {
            BallSlots[score].sprite = PlayerInfo.BallActive;
            score++;
        }
    }
    void Damage(PlayerLife player)
    {
        if (player.playerNumber == PlayerInfo.PlayerNumber)
        {
            LifeCell[damageRecived].fillAmount = 0;
            damageRecived++;
        }
    }
    void Respawn(PlayerLife player)
    {
        if (player.playerNumber == PlayerInfo.PlayerNumber)
        {
            FullLifeBar();
        }

    }

    IEnumerator ChargeLifeBar(float timeRespawn)
    {
        //TEMPO PARA RECARR
        var intervalo = timeRespawn / LifeCell.Length;
        for (int i = 0; i < LifeCell.Length; i++)
        {
            yield return new WaitForSeconds(intervalo);
            LifeCell[i].fillAmount = 1;
        }
    }
    void Death(PlayerLife player)
    {
        if (player.playerNumber == PlayerInfo.PlayerNumber)
        {
            ClearLifeBar();
            StartCoroutine("ChargeLifeBar", player.TotalTimeRespawn);
        }
    }


}
