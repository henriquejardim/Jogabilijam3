using UnityEngine;

public class InputBinder : MonoBehaviour {

    public InputManager[] inputs;

    private string joyTagNumber;

    private int i = 0;

    private bool keyboardAndMouseBinded = false;

    private void Update() {
        Bind();
    }

    public void Bind() {

        if (i == inputs.Length) return;

        var inputManager = inputs[i];

        if (Input.GetButtonDown("j1A")) {
            joyTagNumber = "j1";
        } else if (Input.GetButtonDown("j2A")) {
            joyTagNumber = "j2";
        } else if (Input.GetButtonDown("j3A")) {
            joyTagNumber = "j3";
        } else if (Input.GetButtonDown("j4A")) {
            joyTagNumber = "j4";
        } else if (Input.GetKeyDown(KeyCode.Space) && !keyboardAndMouseBinded) {
            inputManager.binded = true;
            keyboardAndMouseBinded = true;
            inputManager.type = InputManager.InputType.KeyboardMouse;
            i++;
        }

        if (!string.IsNullOrEmpty(joyTagNumber)) {
            inputManager.Bind(joyTagNumber);
            i++;
            joyTagNumber = null;
        }
    }

}
