using UnityEngine;
using UnityEngine.Events;
using XInputDotNetPure;

public class InputBinder : MonoBehaviour {

    public UnityEvent OnBind;

    public InputManager inputManagerPrefab;
    public XInputManager xinputManagerPrefab;

    public InputManager[] inputs;
    public InputManager[] inputsCache;

    [Range(1, 4)]
    public int totalControllers = 2;


    private string joyTagNumber;

    public int i = 0;

    private bool keyboardAndMouseBinded = false;
    private bool j1Binded = false;
    private bool j2Binded = false;
    private bool j3Binded = false;
    private bool j4Binded = false;

    private PlayerIndex index1 = PlayerIndex.One;
    private PlayerIndex index2 = PlayerIndex.Two;
    private PlayerIndex index3 = PlayerIndex.Three;
    private PlayerIndex index4 = PlayerIndex.Four;


    public void Awake() {

    }

    private void Start() {

        for (int index = 0; index < totalControllers; index++) {

            print("TESTE" + i);
            if (inputManagerPrefab == null) continue;
            var manager = Instantiate(xinputManagerPrefab) as InputManager;
            manager.type = InputManager.InputType.XInput;
            manager.PlayerName = "Jogador " + i + 1;
            DontDestroyOnLoad(manager);

            inputs[index] = manager;
            inputsCache[index] = manager;

        }
        DontDestroyOnLoad(gameObject);
    }

    public void Bind() {

        if (i >= inputs.Length) return;

        var inputManager = inputs[i];

        if (inputManager == null) return;

        //if (GamePad.GetState(index).IsConnected && GamePad.GetState(index).Buttons.A == ButtonState.Pressed && !j1Binded) {
        //    joyTagNumber = "j1";
        //    j1Binded = true;
        //} else if (Input.GetButtonDown("j2A") && !j2Binded) {
        //    joyTagNumber = "j2";
        //    j2Binded = true;
        //} else if (Input.GetButtonDown("j3A") && !j3Binded) {
        //    joyTagNumber = "j3";
        //    j3Binded = true;
        //} else if (Input.GetButtonDown("j4A") && !j4Binded) {
        //    joyTagNumber = "j4";
        //    j4Binded = true;
        //} else if (Input.GetKeyDown(KeyCode.Space) && !keyboardAndMouseBinded) {
        //    inputManager.binded = true;
        //    keyboardAndMouseBinded = true;
        //    inputManager.type = InputManager.InputType.KeyboardMouse;
        //    i++;

        //    if (OnBind != null)
        //        OnBind.Invoke();
        //}


        if (GamePad.GetState(index1).IsConnected && GamePad.GetState(index1).Buttons.A == ButtonState.Pressed && !j1Binded) {
            joyTagNumber = "j1";
            j1Binded = true;
            ((XInputManager)inputManager).Bind(index1, joyTagNumber);
 
        } else if (GamePad.GetState(index2).IsConnected && GamePad.GetState(index2).Buttons.A == ButtonState.Pressed && !j2Binded) {
            joyTagNumber = "j2";
            j2Binded = true;
            ((XInputManager)inputManager).Bind(index2, joyTagNumber);
            

        } else if (GamePad.GetState(index3).IsConnected && GamePad.GetState(index3).Buttons.A == ButtonState.Pressed && !j3Binded) {
            joyTagNumber = "j3";
            j3Binded = true;
            ((XInputManager)inputManager).Bind(index3, joyTagNumber);

        } else if (GamePad.GetState(index4).IsConnected && GamePad.GetState(index4).Buttons.A == ButtonState.Pressed && !j4Binded) {
            joyTagNumber = "j4";
            j4Binded = true;
            ((XInputManager)inputManager).Bind(index4, joyTagNumber);

        } else if (Input.GetKeyDown(KeyCode.Space) && !keyboardAndMouseBinded) {
            inputManager = Instantiate(inputManagerPrefab);
            DontDestroyOnLoad(inputManager);
            inputs[i] = inputManager;

            inputManager.PlayerName = "Jogador " + (i + 1);
            inputManager.binded = true;
            keyboardAndMouseBinded = true;
            inputManager.type = InputManager.InputType.KeyboardMouse;
            i++;

            if (OnBind != null)
                OnBind.Invoke();
        }



        if (!string.IsNullOrEmpty(joyTagNumber)) {
            inputManager.Bind(joyTagNumber);
            i++;
            joyTagNumber = null;

            if (OnBind != null)
                OnBind.Invoke();
        }
    }

    public void ResetBind() {
        for (int idx = 0; idx < inputs.Length; idx++) {
            inputs[idx].Unbind();
            inputsCache[idx].Unbind();
        }
        for (int idx = 0; idx < inputs.Length; idx++) {
            inputs[idx] = inputsCache[idx];
        }
        i = 0;
        j1Binded = j2Binded = j3Binded = j4Binded = keyboardAndMouseBinded = false;
    }



}
