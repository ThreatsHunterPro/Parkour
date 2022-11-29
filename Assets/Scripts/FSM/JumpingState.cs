// ReSharper disable All

using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class JumpingState : State
{
    #region Fields
    
        
    
    #endregion
        
    #region Properties
    
        
    
    #endregion
        
    #region Methods
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!brain) return;
        
        brain.Movement.CanMove = false;
        brain.Movement.CanJump = false;
        brain.Movement.IsJumping = true;
        brain.Movement.Animator.SetBool("isJumping", true);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (brain && brain.Sensor.IsCheckingGround)
        {
            animator.SetBool("Jump", false);
            brain.Movement.Animator.SetBool("isJumping", false);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (brain)
        {
            brain.Movement.IsJumping = false;
        }
    }
    
    #endregion
}

