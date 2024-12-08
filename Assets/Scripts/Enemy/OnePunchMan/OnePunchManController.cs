using StatePattern.Enemy;
using StatePattern.Player;
using UnityEngine;

public class OnePunchManController : EnemyController
{
    private OnePunchManStateMachine stateMachine;
    private PlayerController target;
    public PlayerController Target => target;

    public OnePunchManController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
    {
        enemyView.SetController(this);
        CreateStateMachine();
        Debug.Log("State machine created");
        stateMachine.ChangeState(OnePunchManStates.Idle);
    }

    private void CreateStateMachine() => stateMachine = new OnePunchManStateMachine(this);
    public override void UpdateEnemy()
    {
        if (currentState == EnemyState.DEACTIVE)
            return;

        stateMachine.Update();
    }

    public override void PlayerEnteredRange(PlayerController targetToSet)
    {
        base.PlayerEnteredRange(targetToSet);
        target = targetToSet;
        stateMachine.ChangeState(OnePunchManStates.Shooting);
    }

    public override void PlayerExitedRange() => stateMachine.ChangeState(OnePunchManStates.Idle);

}