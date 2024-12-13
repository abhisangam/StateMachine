using StatePattern.Enemy;
using static UnityEditor.VersionControl.Asset;

public interface IStateMachine
{
    public void ChangeState(StatePattern.Enemy.States newState);
}