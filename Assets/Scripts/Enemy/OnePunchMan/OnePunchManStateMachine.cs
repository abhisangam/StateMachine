using StatePattern.Enemy;
using StatePattern.StateMachine;

public class OnePunchManStateMachine : GenericStateMachine<OnePunchManController>
{
    public OnePunchManStateMachine(OnePunchManController Owner) : base(Owner)
    {
        this.Owner = Owner;
        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        States.Add(StatePattern.StateMachine.States.IDLE, new IdleState<OnePunchManController>(this));
        States.Add(StatePattern.StateMachine.States.ROTATING, new RotatingState<OnePunchManController>(this));
        States.Add(StatePattern.StateMachine.States.SHOOTING, new ShootingState<OnePunchManController>(this));
    }
}