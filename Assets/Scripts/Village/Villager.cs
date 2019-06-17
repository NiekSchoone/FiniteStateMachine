using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    private StackFSM brain;
    private Vector3 targetPosition;

    void Start() {
        brain = new StackFSM();

        brain.PushState(GatherResource);
    }

    void Update() {
        brain.Update();
    }

    void GatherResource() {
        if(!InPosition()) {
            brain.PushState(Walk);
        }
    }

    void Sleep() {
        Debug.Log("sleeping");
    }

    void Walk() {
        Vector3.MoveTowards(transform.position, targetPosition, 0.1f);

        if(InPosition()) {
            brain.PopState();
        }
    }

    bool InPosition() {
        if(Vector3.Distance(transform.position, targetPosition) < 2) {
            return true;
        }else {
            return false;
        }
    }
}

public enum ResourceType {
    WHEAT,
    WOOD,
    STONE
}