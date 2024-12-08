using StatePattern.Enemy;
using UnityEngine;

public class IdleState : IState
{
    public new OnePunchManController Owner { get; set; }
    private OnePunchManStateMachine stateMachine;
    private float timer;

    public IdleState(OnePunchManStateMachine stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Debug.Log("Idle Entered");
        ResetTimer();
    }

    public override void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            stateMachine.ChangeState(OnePunchManStates.Rotating);
    }

    public void OnStateExit() => timer = 0;

    private void ResetTimer() => timer = Owner.Data.IdleTime;
}