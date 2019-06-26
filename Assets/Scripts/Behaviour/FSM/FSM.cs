using System;

public class FSM
{
    public Action activeState;

    public FSM() {

    }

    public void SetState(Action newState) {
        activeState = newState;
    }

    public void Update() {
        if(activeState != null) {
            activeState();
        }
    }
}
