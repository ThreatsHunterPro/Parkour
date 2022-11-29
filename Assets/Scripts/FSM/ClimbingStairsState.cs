// ReSharper disable All
using UnityEngine;

public class ClimbingStairsState : State
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
        brain.Movement.IsClimbingStairs = true;
        brain.Movement.Animator.SetBool("isClimbingStairs", true);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (brain && !brain.Sensor.IsCheckingStairs)
        {
            animator.SetBool("ClimbStairs", false);
            brain.Movement.Animator.SetBool("isClimbingStairs", false);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (brain)
        {
            brain.Movement.IsClimbingStairs = false;
        }
    }
    
    #endregion
}