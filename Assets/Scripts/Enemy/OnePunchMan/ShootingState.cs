using StatePattern.Enemy;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class ShootingState : IState
{
    public new OnePunchManController Owner { get; set; }
    private OnePunchManStateMachine stateMachine;

    private float shootTimer;
    public ShootingState(OnePunchManStateMachine stateMachine) => this.stateMachine = stateMachine;
    public override void Enter()
    {
        shootTimer = Owner.Data.RateOfFire;
    }

    public override void Update()
    {
        Quaternion desiredRotation = CalculateRotationTowardsPlayer();
        Owner.SetRotation(RotateTowards(desiredRotation));

        if (IsFacingPlayer(desiredRotation))
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                shootTimer = Owner.Data.RateOfFire;
                Owner.Shoot();
            }
        }
    }

    public override void Exit()
    {
    }

    private Quaternion CalculateRotationTowardsPlayer()
    {
        Vector3 directionToPlayer = Owner.Target.Position - Owner.Position;
        directionToPlayer.y = 0f;
        return Quaternion.LookRotation(directionToPlayer, Vector3.up);
    }

    private Quaternion RotateTowards(Quaternion desiredRotation) => Quaternion.LerpUnclamped(Owner.Rotation, desiredRotation, Owner.Data.RotationSpeed / 30 * Time.deltaTime);

    private bool IsFacingPlayer(Quaternion desiredRotation) => Quaternion.Angle(Owner.Rotation, desiredRotation) < Owner.Data.RotationThreshold;
}