//Created by: Niek Schoone

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Villager : MonoBehaviour
{
    private enum Job
    {
        GATHERER,
        ENGINEER
    }
    private FiniteStateMachine<Villager> FSM;

    public GameObject storehouse;

    [SerializeField] public InteractableObjectList resourceLists;

    public Movement movement;

    [SerializeField] private List<ResourceType> keys = new List<ResourceType>();
    [SerializeField] private List<int> values = new List<int>();

    public Dictionary<ResourceType, int> resourceTable = new Dictionary<ResourceType, int>()
    {
        { ResourceType.GRAIN, 0},
        { ResourceType.ORE, 0},
        { ResourceType.WOOD, 0}
    };

    public int GatheringCap = 10;

    public int totalresourcesGathered = 0;

    void Reset()
    {
        foreach (ResourceType key in resourceTable.Keys)
        {
            keys.Add(key);
        }
        foreach (int value in resourceTable.Values)
        {
            values.Add(value);
        }
        movement = GetComponent<Movement>();
    }

    void Start()
    {
        FSM = new FiniteStateMachine<Villager>();
        FSM.Initialize(this, Idle.Instance);
    }

    public void ChangeState(IFSM<Villager> e)
    {
        FSM.ChangeState(e);
    }

    void Update()
    {
        FSM.Update();
        ShowFakeInpectorDictionary();
    }

    void ShowFakeInpectorDictionary()
    {
        values[0] = resourceTable[ResourceType.GRAIN];
        values[1] = resourceTable[ResourceType.ORE];
        values[2] = resourceTable[ResourceType.WOOD];
    }
}
