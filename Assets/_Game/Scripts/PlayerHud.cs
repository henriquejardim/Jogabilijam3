using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    [HideInInspector]
    public PlayerHudInformation PlayerInfo;
    public int PlayerNumber;
    public Image[] LifeCell = new Image[5];
    public Image[] BallSlots = new Image[4];
    public Image PlayerColor;
    public Text RespawnCounterPlayer;
    public MeshRenderer PlayerRendererColor;

    int score;
    int damageRecived;
    float timeRespawn;
    bool isDeath;
    // Use this for initialization

    void Start()
    {
        var gameManager = FindObjectOfType<GameManager>();
        if (PlayerNumber == 1)
            PlayerInfo = gameManager.player1Information;
        else if (PlayerNumber == 2)
            PlayerInfo = gameManager.player2Information;

        foreach (var player in FindObjectsOfType<PlayerLife>())
        {
            if (player.playerNumber == PlayerNumber)
            {
                player.OnDamage.AddListener(Damage);
                player.OnRespawn.AddListener(Respawn);
                player.OnDeath.AddListener(Death);
            }
        }

        foreach (var ball in FindObjectsOfType<Ball>())
        {
            if (ball.PlayerNumber == PlayerNumber)
            {
                ball.OnScore.AddListener(Score);
                var ballrender = ball.GetComponent<MeshRenderer>();
                ballrender.material = PlayerInfo.ColorMaterial;
            }
        }

        PlayerColor.color = PlayerInfo.PlayerHudColor;
        PlayerRendererColor.material = PlayerInfo.ColorMaterial;
        RespawnCounterPlayer.color = PlayerInfo.RespawnCounterColor;
        for (int i = 0; i < BallSlots.Length; i++)
        {
            BallSlots[i].sprite = PlayerInfo.BallInactive;
            BallSlots[i].color = PlayerInfo.PlayerHudColor;
        }
        FullLifeBar();
    }

    private void FullLifeBar()
    {
        for (int i = 0; i < LifeCell.Length; i++)
        {
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

    private void Score(int playerNumber)
    {
        if (playerNumber == PlayerNumber)
        {
            BallSlots[score].sprite = PlayerInfo.BallActive;
            score++;
        }
    }

    private void Damage(PlayerLife player)
    {
        if (player.playerNumber == PlayerNumber)
        {
            LifeCell[damageRecived].fillAmount = 0;
            damageRecived++;
        }
    }

    private void Respawn(PlayerLife player)
    {
        if (player.playerNumber == PlayerNumber)
        {
            PlayerRendererColor.material = PlayerInfo.ColorMaterial;
            FullLifeBar();
        }

    }

    private IEnumerator ChargeLifeBar(float timeRespawn)
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
        if (player.playerNumber == PlayerNumber)
        {
            ClearLifeBar();
            StartCoroutine("ChargeLifeBar", player.TotalTimeRespawn);
        }
    }


}
