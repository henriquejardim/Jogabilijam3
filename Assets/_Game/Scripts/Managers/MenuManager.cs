using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameManager gameManager;
    public Text controllerText1;
    public Text controllerText2;

    public Button play;
    public EventSystem eventSystem;
    bool playSelected = false;

	// Update is called once per frame
	void Update () {
        var controllersBinded = gameManager.ControllersBinded();
        play.interactable = controllersBinded;
        if (controllersBinded && !playSelected && !eventSystem.alreadySelecting) {
            eventSystem.SetSelectedGameObject(play.gameObject);
            playSelected = true;
        }
        controllerText1.text = GetSupportText(1);
        controllerText2.text = GetSupportText(2);
    }

    public void OnPlay() {
        gameManager.HowToPlay();
    }

    public void OnCredits() {
        gameManager.Credits();
    }

    public void OnExitGame() {
        gameManager.ExitGame();
    }

    public string GetSupportText(int playerNumber) {
        var input = gameManager.JoystickBinded(playerNumber);
        return !input.binded ? "Pressione A/Espaço" :
            input.type == InputManager.InputType.Joystick || input.type == InputManager.InputType.XInput ? "Controle " + input.PlayerTagNumber : "Teclado e Mouse";
    }
    
}
