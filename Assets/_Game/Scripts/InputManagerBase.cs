using UnityEngine;
using XInputDotNetPure;

public class InputManagerBase : MonoBehaviour {

    public enum InputType {
        Joystick,
        KeyboardMouse
    }

    public InputType type = InputType.Joystick;
    public string PlayerName;
    public string PlayerTagNumber;
    public PlayerIndex PlayerIndex;

    public bool binded = false;

    public float triggerSensitity = 0.4f;

    private bool dashPressed;

    public virtual bool FireButton() {
        if (!binded) return false;
        return type == InputType.Joystick ? Input.GetAxis(PlayerTagNumber + "Fire") > triggerSensitity : Input.GetButton("Fire1");
    }

    public virtual bool DashButtonDown() {
        if (!binded) return false;

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
        if (!binded) return 0;

        return Input.GetAxis(PlayerTagNumber + "RV");
    }

    public float RightStickHorizontal() {
        if (!binded) return 0;

        return Input.GetAxis(PlayerTagNumber + "RH");
    }

    public float LeftStickVertical() {
        if (!binded) return 0;

        return type == InputType.Joystick ? Input.GetAxis(PlayerTagNumber + "LV") : Input.GetAxis("Vertical1");
    }

    public float LeftStickHorizontal() {
        if (!binded) return 0;

        return type == InputType.Joystick ? Input.GetAxis(PlayerTagNumber + "LH") : Input.GetAxis("Horizontal1");
    }

    public void Bind(string tagJoy) {
        if (binded) return;
        PlayerTagNumber = tagJoy;
        binded = true;
    }

}
