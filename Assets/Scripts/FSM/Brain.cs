// ReSharper disable All

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Animator), typeof(MovementBehavior), typeof(SensorBehavior))]
public class Brain : MonoBehaviour
{
    #region Fields

    [SerializeField, Header("Brain values")]
    private Animator fsm = null;

    [SerializeField]
    private MovementBehavior movement = null;
    
    [SerializeField]
    private SensorBehavior sensor = null;

    #endregion

    #region Properties
    
    public MovementBehavior Movement => movement;
    public SensorBehavior Sensor => sensor;

    #endregion

    #region Methods

    // Engine methods
    private void Start() => InitFSM();
    
    // Custom methods
    void InitFSM()
    {
        if (!fsm || !movement) return;
        
        State[] _states = fsm.GetBehaviours<State>();
        int _length = _states.Length;
        
        for (int _stateIndex = 0; _stateIndex < _length; _stateIndex++)
        {
            _states[_stateIndex].Init(this);
        }
    }

    #endregion
}

// chaque state modifie le comportement de movementbehavior