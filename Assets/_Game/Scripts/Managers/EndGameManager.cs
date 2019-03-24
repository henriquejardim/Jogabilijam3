using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour {

    public GameManager gameManager;
    public Text victoryText;
    public Text supportVictoryText;

    public Color playerOneColor;
    public Color playerTwoColor;

    public GameObject endGamePanel;
    public GameObject endGameScorePanel;

    public void ShowEndPanel(int playerOneScore, int playerTwoScore, int winner) {
        endGamePanel.SetActive(true);
        endGameScorePanel.SetActive(true);
        var scoreManager = endGameScorePanel.GetComponent<ScoreManager>();
        scoreManager.SetValues(playerOneScore, playerTwoScore);

        if (winner == 1) {
            victoryText.color = playerOneColor;
            supportVictoryText.color = playerOneColor;
            victoryText.text = "CYBERSAMBA dá um baile.";
        } else {
            victoryText.color = playerTwoColor;
            supportVictoryText.color = playerTwoColor;
            victoryText.text = "Nada acontece ... FEIJOADA LASER.";
        }
    }

    public void OnPlayAgain() {
        gameManager.Play();
    }

    public void ToMenuScreen() {
        gameManager.MenuScreen();
    }
}
