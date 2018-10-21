using UnityEngine;
using XInputDotNetPure;

public class XInputManager : InputManager {


    bool playerIndexSet = false;
    public PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    private void Start() {
        type = InputType.XInput; 
    }

    private bool dashed;

    public override bool FireButton() {
        if (!binded) return false;
        state = GamePad.GetState(playerIndex);
        return state.Triggers.Right > triggerSensitity; 
    }

    public override bool DashButtonDown() {
        if (!binded) return false;

        state = GamePad.GetState(playerIndex);

        var dash = state.Triggers.Left;

        if (dashed && dash > triggerSensitity) return false;

        if (dash > triggerSensitity)
            dashed = true;
        else
            dashed = false;

        return dashed;
    }

    public override float RightStickVertical() {
        if (!binded) return 0;

        state = GamePad.GetState(playerIndex);

        return state.ThumbSticks.Right.Y;
    }

    public override float RightStickHorizontal() {
        if (!binded) return 0;
        state = GamePad.GetState(playerIndex);

        return state.ThumbSticks.Right.X; 
     }


    public override float LeftStickVertical() {
        if (!binded) return 0;

        state = GamePad.GetState(playerIndex);
        return state.ThumbSticks.Left.Y;
    }

    public override float LeftStickHorizontal() {
        if (!binded) return 0;

        state = GamePad.GetState(playerIndex);
        return state.ThumbSticks.Left.X;
    }

    public override void Bind(string tagJoy) {
        if (binded) return;
        PlayerTagNumber = tagJoy;
        binded = true;
    }

    public void Bind (PlayerIndex index, string tagJoy) {
        if (binded) return;
        playerIndex = index;
        PlayerTagNumber = tagJoy;
        binded = true;
    }

}
