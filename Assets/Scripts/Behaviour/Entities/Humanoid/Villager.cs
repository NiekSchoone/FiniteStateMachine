using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : Humanoid
{
    public Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();
    public VillagerRole role;
    public ResourceType type;

    private Resource resource;

    public GameObject targetResource;
    public GameObject storeHouse;

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
    targetPosition = targetResource.transform.position;
        if(!resource){
            resource = targetResource.GetComponent<Resource>();
        }
        if(!InPosition()) {
            brain.PushState(Walk);
            return;
        }
        resource.Harvest(1);
        if(resource.value >= 0) {
            resources[type] += 1;
        }else {
            brain.PushState(DepositResource);
        }
        // Debug.Log("gathered: " + resources[type]);
        if(resources[type] >= 750) {
            brain.PushState(DepositResource);
        }
    }

    void DepositResource() {
      targetPosition = storeHouse.transform.position;

      if(!InPosition()) {
          brain.PushState(Walk);
          return;
      }
      resources[type] = 0;
      brain.PopState();
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

    GameObject FindClosestResource(string _tag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(_tag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
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