using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour {
    //[HideInInspector]
    public PlayerColorInformation PlayerInfo;
    public int PlayerNumber;
    public Image[] LifeCell = new Image[5];
    public Image[] BallSlots = new Image[4];
    public Image PlayerColor;
    public Text RespawnCounterPlayer;
    public MeshRenderer PlayerRendererColor;

    public int damageRecived;
    float timeRespawn;
    // Use this for initialization

    public PlayerLife player;
 
    void Start() {
        var gameManager = FindObjectOfType<GameManager>();
        switch (PlayerNumber) {
            case 1:
            PlayerInfo = gameManager.player1Information;
            break;
            case 2:
            PlayerInfo = gameManager.player2Information;
            break;
            case 3:
            PlayerInfo = gameManager.player3Information;
            break;
            case 4:
            PlayerInfo = gameManager.player4Information;
            break;
            default:
            break;
        }

        print("HUD BIND:" + PlayerNumber);
        player.OnDamage.AddListener(Damage);
        player.OnRespawn.AddListener(Respawn);
        player.OnDeath.AddListener(Death);

        PlayerColor.color = PlayerInfo.PlayerHudColor;
        PlayerRendererColor.material = PlayerInfo.ColorMaterial;
        RespawnCounterPlayer.color = PlayerInfo.RespawnCounterColor;

        ClearLifeBar();
        FullLifeBar();
    }

    private void FullLifeBar() {
        for (int i = 0; i < LifeCell.Length; i++) {
            LifeCell[i].fillAmount = 1;
        }
        damageRecived = 0;
    }
    private void ClearLifeBar() {
        for (int i = 0; i < LifeCell.Length; i++) {
            LifeCell[i].fillAmount = 0;
        }
        damageRecived = 0;
    }

    private void Damage(PlayerLife player) {
        if (player.playerNumber == PlayerNumber) {
            print("Hud " + PlayerNumber + " " + damageRecived); 
            LifeCell[damageRecived].fillAmount = 0;
            damageRecived++;
        }
    }

    private void Respawn(PlayerLife player) {
        if (player.playerNumber == PlayerNumber) {
            PlayerRendererColor.material = PlayerInfo.ColorMaterial;
            FullLifeBar();
        }

    }

    private IEnumerator ChargeLifeBar(float timeRespawn) {
        //TEMPO PARA RECARR
        var intervalo = timeRespawn / LifeCell.Length;
        for (int i = 0; i < LifeCell.Length; i++) {
            yield return new WaitForSeconds(intervalo);
            LifeCell[i].fillAmount = 1;
        }
    }

    public void Death(PlayerLife player) {
        if (player.playerNumber == PlayerNumber) {
            print("Hud Death " + PlayerNumber + " " + damageRecived);
            ClearLifeBar();
            StartCoroutine("ChargeLifeBar", player.TotalTimeRespawn);
        }
    }


}
