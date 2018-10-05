using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : MonoBehaviour, IState {

    /// <summary>
    /// Notify the state that the transition process has begun the entering phase
    /// </summary>
    void BeginEnter();

    /// <summary>
    /// Notify the state that the transition process has finished the entering phase
    /// </summary>
    void EndEnter();

    /// <summary>
    /// Execute the state's logic over time. This function should 'yield return' until it has
    /// nothing left to do. It may also dispatch OnBeginExit when it is ready to begin transitioning
    /// to the next state. If it does this, this funtion will no longer be resumed.
    /// </summary>
    IEnumerable Execute();

    /// <summary>
    /// Dispatched when the state is ready to begin transitioning to the next state. This implies
    /// that the transition process will immediately begin the exiting phase.
    /// </summary>
    event EventHandler<StateBeginExitEventArgs> OnBeginExit;

    /// <summary>
    /// Notify the state that the transition process has finished exiting phase.
    /// </summary>
    void EndExit();
}
