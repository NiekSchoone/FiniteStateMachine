//Created by: Niek Schoone

using UnityEngine;
using System.Collections.Generic;

public enum GatheringType
{
    FARMER,
    MINER,
    WOODCUTTER
}
public enum ResourceType
{
    GRAIN,
    ORE,
    WOOD
}

public class Gathering : IFSM<Villager>
{
    static readonly Gathering instance = new Gathering();
    public static Gathering Instance
    {
        get
        {
            return instance;
        }
    }
    static Gathering() { }
    private Gathering() { }

    public GatheringType gatheringType;
    public ResourceType resourceType;

    private GameObject resourceObject;
    private List<GameObject> usedResourceList = new List<GameObject>();

    private float timer = 0;

    public void Enter(Villager e)
    {
        gatheringType = GatheringType.WOODCUTTER;
        SetResourceToGather(gatheringType, e);
        FindClosestResourceToGather(e.storehouse);
        if (resourceObject != null)
        {
            e.movement.InitMoveToLocation(resourceObject, 1.5f);
        }else
        {
            e.ChangeState(Idle.Instance);
        }
    }

    public void Execute(Villager e)
    {
        if ((e.movement.MovementCompleted) && e.totalresourcesGathered < e.GatheringCap)
        {
            GatherResource(e);
        }else if(e.resourceTable[resourceType] == e.GatheringCap)
        {
            e.ChangeState(DepositResources.Instance);
        }
    }
    public void Exit(Villager e)
    {

    }

    private void GatherResource(Villager e)
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            e.resourceTable[resourceType]++;
            e.totalresourcesGathered++;
            timer = 0;
        }
    }

    /// <summary>
    /// Checks which resource it should gather based on the Gatheringtype given.
    /// </summary>
    /// <param name="resource"></param>
    /// <param name="listHolder"></param>
    private void SetResourceToGather(GatheringType resource, Villager e)
    {
        switch (gatheringType)
        {
            case GatheringType.FARMER:
                resourceType = ResourceType.GRAIN;
                usedResourceList = e.resourceLists.fields;
                break;
            case GatheringType.MINER:
                resourceType = ResourceType.ORE;
                usedResourceList = e.resourceLists.mines;
                break;
            case GatheringType.WOODCUTTER:
                resourceType = ResourceType.WOOD;
                usedResourceList = e.resourceLists.trees;
                break;
        }
    }

    /// <summary>
    /// Finds the closest object in the usedResourceList.
    /// </summary>
    /// <param name="storehouse"></param>
    private void FindClosestResourceToGather(GameObject storehouse)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 storehousePosition = storehouse.transform.position;
        foreach (GameObject potentialTarget in usedResourceList)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - storehousePosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        resourceObject = bestTarget;
    }
}