using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : Humanoid
{
    public Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();
    public VillagerRole role;
    public ResourceType type;

    public Transform targetResource;
    public Transform storeHouse;

    protected override void Start() {
        base.Start();

        resources.Add(ResourceType.WHEAT, 0);
        resources.Add(ResourceType.WOOD, 0);
        resources.Add(ResourceType.STONE, 0);

        brain.PushState(GatherResource);

        SetRole(role);
    }

    protected override void Update() {
        base.Update();
    }

    void GatherResource() {
        target = targetResource;

        if(!InPosition()) {
            brain.PushState(Walk);
            return;
        }
        resources[type] += 1;
        Debug.Log("gathered: " + resources[type]);
        if(resources[type] >= 750) {
            brain.PushState(DepositResource);
        }
    }

    void DepositResource() {
        target = storeHouse;

        if(!InPosition()) {
            brain.PushState(Walk);
            return;
        }
        resources[type] = 0;
        brain.PushState(GatherResource);
    }

    void SetRole(VillagerRole _role) {
        this.role = _role;

        switch(role) {
            case VillagerRole.FARMER:
                type = ResourceType.WHEAT;
                targetResource = FindClosestResource(Tags.FIELD);
                break;
            case VillagerRole.LUMBERJACK:
                type = ResourceType.WOOD;
                targetResource = FindClosestResource(Tags.TREE);
                break;
            case VillagerRole.MINER:
                type = ResourceType.STONE;
                targetResource = FindClosestResource(Tags.MINE);
                break;
            default:
                break;
        }
    }

    Transform FindClosestResource(string _tag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(_tag);
        Transform closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go.transform;
                distance = curDistance;
            }
        }
        return closest;
    }
}

public enum VillagerRole {
    FARMER,
    LUMBERJACK,
    MINER
}

public enum ResourceType {
    WHEAT,
    WOOD,
    STONE
}