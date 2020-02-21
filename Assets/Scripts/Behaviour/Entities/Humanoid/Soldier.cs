using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Humanoid
{
    [SerializeField]
    private GameObject patrollingCenter;
    [SerializeField]
    private float patrollingRadius;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        brain.PushState(Patrol);
        target = patrollingCenter.transform;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    private void Patrol() {
        //target = patrollingCenter.transform.position + RandomPointOnCircleEdge(patrollingRadius);
        if (!InPosition())
        {
            brain.PushState(Walk);
            return;
        }
    }

    private void Attack() {
        
    }

    private Vector3 RandomPointOnCircleEdge(float radius)
    {
        Vector2 vector2 = Random.insideUnitCircle.normalized * radius;
        return new Vector3(vector2.x, 0, vector2.y);
    }
}

public enum SoldierRole {
    PATROLLING,
    ATTACKING
}