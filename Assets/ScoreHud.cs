using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHud : MonoBehaviour {

    public Image[] BallSlots = new Image[4];
    public PlayerColorInformation PlayerInfo;
    public int PlayerNumber;

    int score;

    // Use this for initialization
    void Start () {
        foreach (var ball in FindObjectsOfType<Ball>()) {
            if (ball.PlayerNumber == PlayerNumber) {
                ball.OnScore.AddListener(Score);
                var ballrender = ball.GetComponent<MeshRenderer>();
                ballrender.material = PlayerInfo.ColorMaterial;
            }
        }

        for (int i = 0; i < BallSlots.Length; i++) {
            BallSlots[i].sprite = PlayerInfo.BallInactive;
            BallSlots[i].color = PlayerInfo.PlayerHudColor;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Score(int playerNumber) {
        if (playerNumber == PlayerNumber) {
            BallSlots[score].sprite = PlayerInfo.BallActive;
            score++;
        }
    }
}
