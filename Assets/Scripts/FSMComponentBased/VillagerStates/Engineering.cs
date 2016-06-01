using UnityEngine;
using System.Collections;

public class Engineering : IFSM<Villager>
{
    public void Enter(Villager e)
    {
        Debug.Log("Entering the engineering state");
    }
    public void Execute(Villager e)
    {
        Debug.Log("I am busy engineering buildings");
    }
    public void Exit(Villager e)
    {
        Debug.Log("I am exiting the engineering state");
    }
}
