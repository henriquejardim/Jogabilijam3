using UnityEngine;
using UnityEngine.Events;

public class InputBinder : MonoBehaviour {

    public UnityEvent OnBind;

    public InputManager inputManagerPrefab;

    public InputManager[] inputs;

    [Range(1, 4)]
    public int totalControllers = 2;
        

    private string joyTagNumber;

    private int i = 0;
    
    private bool keyboardAndMouseBinded = false;

    public void Awake() {

    }

    private void Start() {
 
        for (int index = 0; index < totalControllers; index++) {

            print("TESTE" + i);

            var manager = Instantiate(inputManagerPrefab) as InputManager;
            manager.PlayerName = "Jogador " + i + 1;
            DontDestroyOnLoad(manager);

            inputs[index] = manager;

        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        //Bind();
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

    

}
