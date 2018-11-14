using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public MoveCharController player1;
    public MoveCharController player2;

    public PlayerHudInformation player1Information;
    public PlayerHudInformation player2Information;

    public enum GameState {
        Start,
        Menu,
        Credits,
        HowToPlay,
        JoystickBind,
        Gaming,
        End
    }

    public GameState state = GameState.Start;
    public InputBinder binder;

    // Use this for initialization
    void Start() {
        Application.targetFrameRate = 60;

        if (binder == null)
            binder = FindObjectOfType<InputBinder>();

        if (state == GameState.Start)
            binder.OnBind.AddListener(OnBind);

        if (state == GameState.Gaming) {
            player1.BindInputManager(binder.inputs[0]);
            player2.BindInputManager(binder.inputs[1]);
        }

    }

    internal void ExitGame() {
        Application.Quit();
    }

    internal void Credits() {
        SceneManager.LoadScene(3);
    }

    internal void Play() {
        SceneManager.LoadScene(2);
        ChangeState(GameState.Gaming);
    }

    internal void HowToPlay() {
        SceneManager.LoadScene(4);
        ChangeState(GameState.Gaming);
    }

    // Update is called once per frame
    void Update() {
        switch (state) {
            case GameState.Start:
            binder.Bind();
            break;
            case GameState.Menu:
            break;
            case GameState.JoystickBind:
            break;
            case GameState.Gaming:
            binder.Bind();
            break;
            case GameState.HowToPlay:
            if (Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Cancel"))
                Play();
            break;
            case GameState.Credits:
            if (Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Cancel"))
                MenuScreen();
            break;
            case GameState.End:
            break;
            default:
            break;
        }
    }

    internal void MenuScreen() {
        SceneManager.LoadScene(1);
        ChangeState(GameState.Menu);
    }

    public void OnBind() {
        SceneManager.LoadScene(1);
        ChangeState(GameState.Menu);
    }

    public bool ControllersBinded() {
        return binder.inputs.All(i => i.binded);
    }

    public void ChangeState(GameState newState) {
        switch (newState) {
            case GameState.Start:
            break;
            case GameState.Menu:
            break;
            case GameState.JoystickBind:
            break;
            case GameState.Gaming:
            break;
            case GameState.End:
            break;
            default:
            break;
        }
    }

    public InputManager JoystickBinded(int playerNumber) {
        return binder.inputs[playerNumber - 1];
    }
}
