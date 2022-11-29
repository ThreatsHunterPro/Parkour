// ReSharper disable All
using UnityEngine;

public class ClimbingLadderState : State
{
    #region Fields
    
        
    
    #endregion
        
    #region Properties
    
        
    
    #endregion
        
    #region Methods
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!brain) return;
        
        brain.Movement.CanJump = false;
        brain.Movement.IsMovingUp = true;
        brain.Movement.Animator.SetBool("isClimbingLadder", true);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (brain && !brain.Sensor.IsCheckingLadder)
        {
            animator.SetBool("ClimbLadder", false);
            brain.Movement.Animator.SetBool("isClimbingLadder", false);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (brain)
        {
            brain.Movement.IsMovingUp = false;
        }
    }
    
    #endregion
}