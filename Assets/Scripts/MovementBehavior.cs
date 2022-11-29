// ReSharper disable All
using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class MovementBehavior : MonoBehaviour
{
    #region Fields
    
    private float currentSpeed = 0.0f;
    private Vector3 destination = Vector3.zero;
        
    [SerializeField, Header("Movement values"), Range(0.0f, 100.0f)]
    private float walkSpeed = 3.0f;
    
    [SerializeField, Range(0.0f, 100.0f)]
    private float sprintSpeed = 6.0f;
    
    [SerializeField, Range(0.0f, 100.0f)]
    private float rotateSpeed = 15.0f;
    
    [SerializeField, Header("Stairs values"), Range(0.0f, 100.0f)]
    private float walkingUpStairsSpeed = 1.5f;
    
    [SerializeField, Range(0.0f, 100.0f)]
    private float runningUpStairsSpeed = 3.0f;

    [SerializeField, Header("Jump values"), Range(0.0f, 100.0f)]
    private float jumpForce = 10.0f;
    
    [SerializeField, Range(0.0f, 100.0f)]
    private float gravity = 10.0f;
    
    [SerializeField, Header("Ref values")]
    private CharacterController controller = null;
    
    [SerializeField]
    private Animator animator = null;
    
    #endregion
        
    #region Properties

    private bool IsValidController => controller;
    
    public bool CanMove { get; set; } = true;
    public bool CanSprint { get; set; } = true;
    public bool CanJump { get; set; } = true;
    
    public bool IsSprinting { get; set; } = false;
    public bool IsJumping { get; set; } = false;
    public bool IsFalling { get; set; } = false;
    public bool IsMovingUp { get; set; } = false;
    public bool IsClimbingStairs { get; set; } = false;
    public bool IsCrossing { get; set; } = false;

    public Animator Animator => animator;
    
    #endregion
        
    #region Methods
    
    // Engine methods
    private void Update()
    {
        if (CanSprint)
        {
            Sprint(Input.GetKey(KeyCode.LeftShift));
        }
            
        if (CanJump)
        {
            Jump();
        }
        
        if (CanMove)
        {
            if (IsMovingUp)
            {
                MoveUp();
            }

            else
            {
                Move();
                Rotate(Input.GetAxis("Mouse X"));
            }

            if (IsValidController)
            {
                controller.Move(destination * currentSpeed * Time.deltaTime);
            }
        }
    }

    // Custom methods
    private void Move()
    {
        float _horizontalValue = Input.GetAxis("Horizontal");
        float _verticalValue = Input.GetAxis("Vertical");

        if (animator)
        {
            animator.SetFloat("horizontalSpeed", _horizontalValue);
            animator.SetFloat("verticalSpeed", _verticalValue);
        }
       
        destination = transform.TransformDirection(new Vector3(_horizontalValue, 0.0f, _verticalValue));
        currentSpeed = IsClimbingStairs ? walkingUpStairsSpeed : walkSpeed;
    }
    private void Rotate(float _value)
    {
        if (_value.Equals(0.0f)) return;
        transform.localEulerAngles += transform.up * _value * rotateSpeed * Time.deltaTime * 10.0f;
    }
    private void MoveUp()
    {
        // climb ladder
    }
    private void Sprint(bool _isSprinting)
    {
        if (animator)
        {
            animator.SetBool("isSprinting", IsSprinting = _isSprinting);
        }
            
        if (_isSprinting)
        {
            currentSpeed = IsClimbingStairs ? runningUpStairsSpeed : sprintSpeed;  
        }
    }
    private void Jump()
    {
        if (animator)
        {
            animator.SetBool("isJumping", IsJumping = Input.GetKeyDown(KeyCode.Space));
        }
        
        if (IsJumping)
        {
            destination.y += jumpForce;
        }
        destination.y -= gravity * 10.0f * Time.deltaTime;
    }

    #endregion
}

// Lerp le jump
// Slide
// Equilibre
// Grimper échelle