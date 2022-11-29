// ReSharper disable All
using UnityEngine;

public class SlidingState : State
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
        brain.Movement.CanJump = false;
        brain.Movement.Animator.SetBool("isSliding", true);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (brain && !brain.Sensor.IsCheckingBeam)
        {
            animator.SetBool("Slide", false);
            brain.Movement.Animator.SetBool("isSliding", false);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
    #endregion
}