using UnityEngine;
using UnityEngine.EventSystems;
using XInputDotNetPure;

public class SelectInput : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selected;

    private bool buttonSelected = false;
    private PlayerIndex playerIndex;
    private bool playerIndexSet;
    private GamePadState prevState;
    private GamePadState state;

    // Update is called once per frame
    void Update () {

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        if (!playerIndexSet || !prevState.IsConnected) {
            for (int i = 0; i < 4; ++i) {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected) {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }

        prevState = state;
        state = GamePad.GetState(playerIndex);

        var vertical = prevState.ThumbSticks.Left.Y;
    
    #endif

     #if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
         var vertical = Input.GetAxis("Vertical");
     #endif

        if (vertical != 0 && !buttonSelected) {
            eventSystem.SetSelectedGameObject(selected);
            buttonSelected = true;
        }
	}

    private void OnDisable() {
        buttonSelected = false;
    }
}
