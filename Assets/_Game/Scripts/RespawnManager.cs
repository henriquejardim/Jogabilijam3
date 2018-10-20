using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnManager : MonoBehaviour {

    public PlayerLife playerOne;
    public PlayerLife playerTwo;

    public StartTimer respawnTextPOne;
    public StartTimer respawnTextPTwo;

    private bool bindedEvents = false;
    private MatchManager matchManager;

    void Start() {
        matchManager = FindObjectOfType<MatchManager>();
    }

    private void Update() {
        if (bindedEvents) return;

        if (matchManager.MatchStarted()) {
            BindEvents();
        }
    }

    private void BindEvents() {
        playerOne.OnDeath.AddListener((playerLife) => {
            respawnTextPOne.gameObject.SetActive(true);
            respawnTextPOne.startTime = playerLife.TotalTimeRespawn + 1;
        });

        playerTwo.OnDeath.AddListener((playerLife) => {
            respawnTextPTwo.gameObject.SetActive(true);
            respawnTextPTwo.startTime = playerLife.TotalTimeRespawn + 1;
        });
        bindedEvents = true;
    }
}
