using StatePattern.Enemy;
using System;
using System.Collections.Generic;
using UnityEngine;

public class OnePunchManStateMachine
{
    private OnePunchManController Owner;

    protected Dictionary<OnePunchManStates, IState> States = new Dictionary<OnePunchManStates, IState>();

    private IState currentState;
    public OnePunchManStateMachine(OnePunchManController Owner)
    {
        this.Owner = Owner;
        CreateStates();
        SetOwner();
    }

    public void Update()
    {
        Debug.Log("State machine updating");
        currentState?.Update();
    }

    private void CreateStates()
    {
        States.Add(OnePunchManStates.Idle, new IdleState(this));
        States.Add(OnePunchManStates.Rotating, new RotatingState(this));
        States.Add(OnePunchManStates.Shooting, new ShootingState(this));
    }

    private void SetOwner()
    {
        foreach (var state in States.Values)
        {
            state.Owner = this.Owner;
        }
    }

    protected void ChangeState(IState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }

    public void ChangeState(OnePunchManStates newState) 
    { 
        ChangeState(States[newState]); 
        Debug.Log("State changed to " + newState);
    }
}