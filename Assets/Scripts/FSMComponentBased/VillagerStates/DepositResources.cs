using UnityEngine;
using System.Collections.Generic;

public class DepositResources : IFSM<Villager>
{
    static readonly DepositResources instance = new DepositResources();
    public static DepositResources Instance
    {
        get
        {
            return instance;
        }
    }
    static DepositResources() { }
    private DepositResources() { }

    public void Enter(Villager e)
    {
        e.movement.InitMoveToLocation(e.storehouse, 3f);
    }
    public void Execute(Villager e)
    {
        Debug.Log("I am depositing resources");
        
    }
    public void Exit(Villager e)
    {
        Debug.Log("I am exiting the state to deposit carried resources");
    }

    void DepositCarriedResources(Dictionary<ResourceType, int> resourceDelivery)
    {
        foreach(int value in resourceDelivery.Values)
        {

        }
    }

}