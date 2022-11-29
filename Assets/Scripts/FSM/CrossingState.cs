// ReSharper disable All
using UnityEngine;

public class CrossingState : State
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
        brain.Movement.CanSprint = false;
        brain.Movement.IsCrossing = true;
        brain.Movement.Animator.SetBool("isCrossing", true);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (brain && !brain.Sensor.IsCheckingVoidAround)
        {
            animator.SetBool("Cross", false);
            brain.Movement.Animator.SetBool("isCrossing", false);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (brain)
        {
            brain.Movement.IsCrossing = false;
        }
    }
    
    #endregion
}