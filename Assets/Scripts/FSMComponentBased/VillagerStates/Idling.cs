//Created by: Niek Schoone

using UnityEngine;
using System.Collections;

public class Idle : IFSM<Villager>
{
    static readonly Idle instance = new Idle();
    public static Idle Instance
    {
        get
        {
            return instance;
        }
    }
    static Idle() { }
    private Idle() { }

    public void Enter(Villager e)
    {
        Debug.Log("Entering the idle state");
        e.ChangeState(Gathering.Instance);
    }
    public void Execute(Villager e)
    {
        Debug.Log("I am not really busy at all");
    }
    public void Exit(Villager e)
    {
        Debug.Log("I am exiting the idle state");
    }
}