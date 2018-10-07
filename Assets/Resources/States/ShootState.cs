using FSMLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : MonoBehaviour, IState {

    bool shot_happened = false;

    /// <summary>
    /// Notify the state that the transition process has begun the entering phase
    /// </summary>
    public void BeginEnter() { }

    /// <summary>
    /// Notify the state that the transition process has finished the entering phase
    /// </summary>
    public void EndEnter() { }

    /// <summary>
    /// Execute the state's logic over time. This function should 'yield return' until it has
    /// nothing left to do. It may also dispatch OnBeginExit when it is ready to begin transitioning
    /// to the next state. If it does this, this funtion will no longer be resumed.
    /// </summary>
    public IEnumerable Execute()
    {
        GameObject.FindGameObjectWithTag("Atirador Móvel").transform.GetComponentInChildren<CanhaoTeleguiado>().Fogo();
        shot_happened = true;
        var nextState = new AimingState();
        var transition = new ScriptShootAimingTransition();
        var eventArgs = new StateBeginExitEventArgs(nextState, transition);
        OnBeginExit(this, eventArgs);
        yield return 0;
    }

    /// <summary>
    /// Dispatched when the state is ready to begin transitioning to the next state. This implies
    /// that the transition process will immediately begin the exiting phase.
    /// </summary>
    public event EventHandler<StateBeginExitEventArgs> OnBeginExit;

    /// <summary>
    /// Notify the state that the transition process has finished exiting phase.
    /// </summary>
    public void EndExit() { }
}
