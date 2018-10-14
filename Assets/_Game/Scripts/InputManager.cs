using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
   
    public enum InputType {
        Joystick,
        KeyboardMouse
    }

    public string PlayerName;
    public string PlayerTagNumber;

    public float triggerSensitity = 0.4f;

    private bool dashPressed;

    public bool FireButton() {
        return Input.GetAxis(PlayerTagNumber + "Fire") > triggerSensitity;
    }

    public bool DashButtonDown() {
        var dash = Input.GetAxis(PlayerTagNumber+"Dash");

        if (dashPressed && dash > 0.4) return false;

        if (dash > 0.4)
            dashPressed = true;
        else
            dashPressed = false;

        return dashPressed;
    }

    public float RightStickVertical() {
        return Input.GetAxis(PlayerTagNumber+ "RV");
    }

    public float RightStickHorizontal() {
        return Input.GetAxis(PlayerTagNumber + "RH");
    }

    public float LeftStickVertical() {
        return Input.GetAxis(PlayerTagNumber + "LV");
    }

    public float LeftStickHorizontal() {
        return Input.GetAxis(PlayerTagNumber + "LH");
    }
}
