using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class ChasingState : IState
    {
        public EnemyController Owner { get; set; }
        private IStateMachine stateMachine;
        private float targetRotation;

        public ChasingState(IStateMachine stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter() {}

        public void Update()
        {
            
        }

        public void OnStateExit() { }

        private Vector3 CalculateRotation() => Vector3.up * Mathf.MoveTowardsAngle(Owner.Rotation.eulerAngles.y, targetRotation, Owner.Data.RotationSpeed * Time.deltaTime);

        private bool IsRotationComplete() => Mathf.Abs(Mathf.Abs(Owner.Rotation.eulerAngles.y) - Mathf.Abs(targetRotation)) < Owner.Data.RotationThreshold;
    }
}