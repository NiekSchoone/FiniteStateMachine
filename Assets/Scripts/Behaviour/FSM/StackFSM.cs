using System;
using System.Collections.Generic;

public class StackFSM {
    public Stack<Action> stack;

    public StackFSM() {
        stack = new Stack<Action>();
    }

    public void PopState() {
        stack.Pop();
    }

    public void PushState(Action state) {
      if(GetCurrentState() != state) {
        stack.Push(state);
      }
    }

    public void Update() {
        Action currentStateAction = GetCurrentState();

        if(currentStateAction != null) {
            currentStateAction();
        }
    }

    public Action GetCurrentState() {
      return stack.Count > 0 ? stack.Peek() : null;
    }
}
