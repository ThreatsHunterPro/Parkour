// ReSharper disable All
using System;
using System.Collections;
using UnityEngine;

public class SensorBehavior : MonoBehaviour
{
    #region Fields

    [SerializeField, Header("Check ground values"), Range(0.0f, 10.0f)]
    private float groundCheckDistance = 1.0f;
    
    [SerializeField, Header("Check beam values"), Range(0.0f, 100.0f)]
    private float beamCheckDistance = 10.0f;
        
    [SerializeField]
    private Vector3 checkBeamOffset = Vector3.zero,
            checkPathForSlideOffset = Vector3.zero;
    
    [SerializeField, Header("Check stairs values"), Range(0.0f, 100.0f)]
    private float stairsCheckDistance = 10.0f;
    
    [SerializeField]
    private Vector3 checkStairsOffset = Vector3.zero;

    [SerializeField] 
    private LayerMask stairsLayer = 0;
    
    [SerializeField, Header("Check ladder values"), Range(0.0f, 100.0f)]
    private float ladderCheckDistance = 10.0f;
    
    [SerializeField]
    private Vector3 checkLadderOffset = Vector3.zero;

    [SerializeField] 
    private LayerMask ladderLayer = 0;
    
    [SerializeField, Header("Check void values"), Range(0.0f, 100.0f)]
    private float voidCheckDistance = 10.0f;

    [SerializeField, Range(0.0f, 100.0f)]
    private float checkVoidGap = 2.0f;

    #endregion
        
    #region Properties

    #region Private

    // VERIFIER LES OFFSETS LOCAUX
    // Beam
    private Vector3 CheckBeamOffset => GetLocalVector(checkBeamOffset);
    private Vector3 CheckPathForSlideOffset => GetLocalVector(checkPathForSlideOffset);
    
    // Stairs
    private Vector3 CheckStairsOffset => GetLocalVector(checkStairsOffset);
    
    // Ladder
    private Vector3 CheckLadderOffset => GetLocalVector(checkLadderOffset);
    
    // Cross
    private Vector3 CheckVoidOnLeftOffset => GetLocalVector(new Vector3(0.0f, 0.0f, -checkVoidGap)); // add gap on local left
    private Vector3 CheckVoidOnRightOffset => GetLocalVector(new Vector3(0.0f, 0.0f, checkVoidGap)); // add gap on local right
    
    #endregion
    
    #region Public
    public bool IsCheckingGround { get; private set; } = true;
    public bool IsCheckingBeam { get; private set; } = false;
    public bool IsCheckingStairs { get; private set; } = false;
    public bool IsCheckingLadder { get; private set; } = false;
    public bool IsCheckingVoidAround { get; private set; } = false;
    
    #endregion

    #endregion
        
    #region Methods
    
    // Engine methods
    private void Update() => StartCoroutine(Analyse());
    private void OnDrawGizmos()
    {
        // Ground
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * groundCheckDistance);
        
        // Beam
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(CheckBeamOffset, CheckBeamOffset + transform.forward * beamCheckDistance);
        Gizmos.DrawLine(CheckPathForSlideOffset, CheckPathForSlideOffset + transform.forward * beamCheckDistance);
        
        // Stairs
        Gizmos.color = Color.red;
        Gizmos.DrawLine(CheckStairsOffset, CheckStairsOffset + transform.forward * stairsCheckDistance);
        
        // Ladder
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(CheckLadderOffset, CheckLadderOffset + transform.forward * ladderCheckDistance);
        
        // Cross
        Gizmos.color = Color.green;
        Gizmos.DrawLine(CheckVoidOnLeftOffset, CheckVoidOnLeftOffset - transform.up * voidCheckDistance);
        Gizmos.DrawLine(CheckVoidOnRightOffset, CheckVoidOnRightOffset - transform.up * voidCheckDistance);
    }

    // Custom methods
    private IEnumerator Analyse()
    {
        yield return new WaitForSeconds(3.0f);
        
        // Check ground 
        IsCheckingGround = Physics.Raycast(transform.position, -transform.up, groundCheckDistance); 
        print("IsCheckingGround : " + IsCheckingGround);
        
        // Check beam 
        IsCheckingBeam = Physics.Raycast(transform.position + checkBeamOffset, transform.forward, beamCheckDistance) 
                         && !Physics.Raycast(CheckPathForSlideOffset, transform.forward, beamCheckDistance);
        // print("IsCheckingBeam : " + IsCheckingBeam);
          
        // check stairs
        IsCheckingStairs = Physics.Raycast(transform.position + checkStairsOffset, transform.forward, stairsCheckDistance, stairsLayer);
        print("IsCheckingStairs : " + IsCheckingStairs);
        
        // check ladder
        IsCheckingLadder = Physics.Raycast(transform.position + checkLadderOffset, transform.forward, ladderCheckDistance, ladderLayer);
        // print("IsCheckingLadder : " + IsCheckingLadder);
        
        // check cross
        IsCheckingVoidAround = Physics.Raycast(transform.position + checkLadderOffset, transform.forward, ladderCheckDistance, ladderLayer)
                               && Physics.Raycast(CheckPathForSlideOffset, transform.forward, beamCheckDistance);
        // print("IsCheckingVoidAround : " + IsCheckingVoidAround);
        
        // ** IK ** \\
        
        // check wall
        
        // check inclinaison sol

        // check mur proches
    }

    private Vector3 GetLocalVector(Vector3 _vector)
    {
        Vector3 _x = transform.right * _vector.x;
        Vector3 _y = transform.up * _vector.y;
        Vector3 _z = transform.forward * _vector.z;
        return transform.position + _x + _y + _z;
    }
    
    #endregion
}