using UnityEngine;

public class InputManager : MonoBehaviour {

    public enum InputType {
        Joystick,
        KeyboardMouse
    }

    public InputType type = InputType.Joystick;
    public string PlayerName;
    public string PlayerTagNumber;

    public bool binded = false;

    public float triggerSensitity = 0.4f;

    private bool dashPressed;

    public bool FireButton() {
        return type == InputType.Joystick ? Input.GetAxis(PlayerTagNumber + "Fire") > triggerSensitity : Input.GetButton("Fire1");
    }

    public bool DashButtonDown() {

        if (type == InputType.KeyboardMouse) {
            return Input.GetKeyDown(KeyCode.Space);
        }

        var dash = Input.GetAxis(PlayerTagNumber + "Dash");

        if (dashPressed && dash > triggerSensitity) return false;

        if (dash > triggerSensitity)
            dashPressed = true;
        else
            dashPressed = false;

        return dashPressed;
    }

    public float RightStickVertical() {
        return Input.GetAxis(PlayerTagNumber + "RV");
    }

    public float RightStickHorizontal() {
        return Input.GetAxis(PlayerTagNumber + "RH");
    }

    public float LeftStickVertical() {
        return type == InputType.Joystick ? Input.GetAxis(PlayerTagNumber + "LV") : Input.GetAxis("Vertical");
    }

    public float LeftStickHorizontal() {
        return type == InputType.Joystick ? Input.GetAxis(PlayerTagNumber + "LH") : Input.GetAxis("Horizontal");
    }

    public void Bind(string tagJoy) {
        if (binded) return;
        PlayerTagNumber = tagJoy;
        binded = true;
    }

}
