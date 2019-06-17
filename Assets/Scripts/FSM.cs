using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
