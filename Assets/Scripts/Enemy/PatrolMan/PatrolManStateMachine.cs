using StatePattern.Enemy;
using System.Collections.Generic;

public class PatrolManStateMachine : IStateMachine
{
    private PatrolManController Owner;
    private IState currentState;
    protected Dictionary<States, IState> States = new Dictionary<States, IState>();

    public PatrolManStateMachine(PatrolManController Owner)
    {
        this.Owner = Owner;
        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        States.Add(StatePattern.Enemy.States.IDLE, new IdleState(this));
        States.Add(StatePattern.Enemy.States.IDLE, new PatrollingState(this));
        States.Add(StatePattern.Enemy.States.IDLE, new ChasingState(this));
        States.Add(StatePattern.Enemy.States.IDLE, new ShootingState(this));
    }

    private void SetOwner()
    {
        foreach (IState state in States.Values)
        {
            state.Owner = Owner;
        }
    }

    public void Update() => currentState?.Update();

    public void ChangeState(States newState)
    {
        throw new System.NotImplementedException();
    }
}