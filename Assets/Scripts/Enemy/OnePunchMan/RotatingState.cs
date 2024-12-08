using StatePattern.Enemy;
using UnityEngine;

public class RotatingState : IState
{
    public new OnePunchManController Owner { get; set; }
    private OnePunchManStateMachine stateMachine;
    private float targetRotation;

    public RotatingState(OnePunchManStateMachine stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter() => targetRotation = (Owner.Rotation.eulerAngles.y + 180) % 360;

    public override void Update()
    {
        // Calculate and set the character's rotation based on the target rotation.
        Debug.Log("Rotating");
        Owner.SetRotation(CalculateRotation());
        if (IsRotationComplete())
            stateMachine.ChangeState(OnePunchManStates.Idle);
    }

    public void OnStateExit() => targetRotation = 0;

    private Vector3 CalculateRotation() 
    {
        Quaternion rotation = Owner.Rotation;
        float rotationSpeed = Owner.Data.RotationSpeed;
        return Vector3.up* Mathf.MoveTowardsAngle(rotation.eulerAngles.y, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private bool IsRotationComplete() => Mathf.Abs(Mathf.Abs(Owner.Rotation.eulerAngles.y) - Mathf.Abs(targetRotation)) < Owner.Data.RotationThreshold;
}