using FSMLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAimingPatrolTransition : IStateTransition
{
    /// <summary>
    /// Exit the current state over time. This function should 'yield return' until the exit process
    /// is finished.
    /// </summary>
    public IEnumerable Exit() { yield return 0; }

    /// <summary>
    /// Enter the next state over time. This function should 'yield return' until the enter process
    /// is finished.
    /// </summary>
    public IEnumerable Enter() { yield return 0; }
}
