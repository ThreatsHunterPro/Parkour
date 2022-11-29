// ReSharper disable All
using UnityEngine;

public class MovingState : State
{
    #region Fields
    
        
    
    #endregion
        
    #region Properties
    
        
    
    #endregion
        
    #region Methods
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!brain) return;

        brain.Movement.CanMove = true;
        brain.Movement.CanJump = true;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!brain) return;

        if (brain.Movement.IsJumping)
        {
            animator.SetBool("Jump", true);
        }
        
        else if (!brain.Sensor.IsCheckingGround)
        {
            animator.SetBool("Fall", true);
        }
        
        else if (brain.Sensor.IsCheckingBeam && brain.Movement.IsSprinting)
        {
            animator.SetBool("Slide", true);
        }
        
        else if (brain.Sensor.IsCheckingStairs)
        {
            animator.SetBool("ClimbStairs", true);
        }
        
        else if (brain.Sensor.IsCheckingLadder)
        {
            animator.SetBool("ClimbLadder", true);
        }
        
        else if (brain.Sensor.IsCheckingVoidAround)
        {
            animator.SetBool("Cross", true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    #endregion
}