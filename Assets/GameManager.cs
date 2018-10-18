﻿using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public MoveCharController player1;
    public MoveCharController player2;

    public enum GameState {
        Start,
        Menu,
        JoystickBind,
        Gaming,
        End
    }

    public GameState state = GameState.Start;
    public InputBinder binder;

    // Use this for initialization
    void Start() {
        if (binder == null)
            binder = FindObjectOfType<InputBinder>();

        if (state == GameState.Start)
            binder.OnBind.AddListener(OnBind);

        if (state == GameState.Gaming) {
            player1.BindInputManager(binder.inputs[0]);
            player2.BindInputManager(binder.inputs[1]);
        }

    }

    internal void Play() {
        SceneManager.LoadScene(2);
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
            case GameState.End:
            break;
            default:
            break;
        }
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

    public void JoystickBind() {

    }
}