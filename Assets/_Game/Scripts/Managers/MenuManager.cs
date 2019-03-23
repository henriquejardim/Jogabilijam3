using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameManager gameManager;
    public Text controllerText1;
    public Text controllerText2;
    public Text controllerText3;
    public Text controllerText4;

    public Button play;
    public Button playX2;
    public EventSystem eventSystem;


	// Update is called once per frame
	void Update () {
        //var controllersBinded = gameManager.ControllersBinded();
        //play.interactable = controllersBinded;
        //if (controllersBinded && !playSelected && !eventSystem.alreadySelecting) {
        //    eventSystem.SetSelectedGameObject(play.gameObject);
        //    playSelected = true;
        //}

        if (gameManager.state == GameManager.GameState.JoystickBind) {
            controllerText1.text = GetSupportText(1);
            controllerText2.text = GetSupportText(2);
            controllerText3.text = GetSupportText(3);
            controllerText4.text = GetSupportText(4);
        }
    
    }

    public void OnPlay() {
        gameManager.HowToPlay();
    }

    public void OnSelectModeX1() {
        Data.selectedMode = 1;
        gameManager.JoystickBind();
    }

    public void OnSelectModeX2() {
        Data.selectedMode = 2;
        gameManager.JoystickBind();
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
