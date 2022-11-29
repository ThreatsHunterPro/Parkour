// ReSharper disable All
using UnityEngine;
using UnityEngine.Animations;

public abstract class State : StateMachineBehaviour
{
    #region Fields

    protected Brain brain = null;

    #endregion

    #region Methods

    public void Init(Brain _brain)
    {
        brain = _brain;
    }

    #endregion
}