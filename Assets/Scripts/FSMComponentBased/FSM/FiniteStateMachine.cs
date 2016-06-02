//Created by: Niek Schoone

using UnityEngine;
using System.Collections;

public class FiniteStateMachine<T>
{
    private T user;                 //Represents the user of the entity that a state can be used by.
    private IFSM<T> currentState;   //Represents the state it is executing at the moment.
    private IFSM<T> previousState;  //Represents the state that was being executed before the currentstate.
    private IFSM<T> defaultState;   //Represents the state that was assigned at initialization.

    /// <summary>
    /// Starts the finite state machine for a generic type "user".
    /// </summary>
    /// <param name="myUser"></param>
    /// <param name="initialState"></param>
    public void Initialize(T myUser, IFSM<T> initialState)
    {
        user = myUser;
        defaultState = initialState;
        ChangeState(initialState);
    }

    /// <summary>
    /// Changes the current state to a new one, and calls the Enter and Exit methods.
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(IFSM<T> newState)
    {
        previousState = currentState;
        if (currentState != null)
        {
            currentState.Exit(user);
        }
        currentState = newState;
        if(currentState != null)
        {
            currentState.Enter(user);
        }
    }

    public void Update()
    {
        if (currentState != null)
        {
            //Updates the currentStates "Execute" function every frame for the user.
            currentState.Execute(user);
        }
    }

    /// <summary>
    /// Reverts to the state which was called previous to the current one.
    /// </summary>
    public void RevertToPreviousState()
    {
        if (previousState != null)
        {
            ChangeState(previousState);
        }
    }
    
    /// <summary>
    /// Reverts to the state in which the state machine was initialized (often some kind of idle state).
    /// </summary>
    public void RevertToDefaultState()
    {
        if (defaultState != null)
        {
            ChangeState(defaultState);
        }
    }
}
