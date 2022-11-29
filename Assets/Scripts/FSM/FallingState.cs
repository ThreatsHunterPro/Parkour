// ReSharper disable All
using UnityEngine;

public class FallingState : State
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
        brain.Movement.IsFalling = true;
        brain.Movement.Animator.SetBool("isFalling", true);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (brain && brain.Sensor.IsCheckingGround)
        {
            animator.SetBool("Fall", false);
            brain.Movement.Animator.SetBool("isFalling", false);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (brain)
        {
            brain.Movement.IsFalling = false;
        }
    }

    #endregion
}


// peut bouger pour changer l'endroit de l'atterrissage
// peut tourner normalement
// Peut pas sauter, slider, grimper, traverser