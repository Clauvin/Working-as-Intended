using FSMLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScriptFSMBrain : MonoBehaviour, IStateMachine
{
    /// <summary>
    /// The current state
    /// </summary>
    private IState state;

    /// <summary>
    /// The next state (to transition to)
    /// </summary>
    private IState nextState;

    /// <summary>
    /// Transition to use to get to the next state
    /// </summary>
    private IStateTransition transition;

    /// <summary>
    /// Create the state machine with an initial state
    /// </summary>
    /// <param name="initialState">Initial state. BeginEnter() and EndEnter() will be called
    /// on it immediately</param>
    public ScriptFSMBrain(IState initialState)
    {
        State = initialState;
        state.EndEnter();
    }

    /// <summary>
    /// Execute the initial state and any subsequent states and transitions until there are no more
    /// states to execute.
    /// </summary>
    public IEnumerable Execute()
    {
        while (true)
        {
            // Execute the current state until it transitions or stops executing
            for (
                var e = state.Execute().GetEnumerator();
                transition == null && e.MoveNext();
            )
            {
                yield return e.Current;
            }

            // Wait until the current state transitions
            while (transition == null)
            {
                yield return null;
            }

            // Stop listening for the current state to transition
            // This prevents accidentally transitioning twice
            state.OnBeginExit -= HandleStateBeginExit;

            // There is no next state to transition to
            // This means the state machine is finished executing
            if (nextState == null)
            {
                break;
            }

            // Run the transition's exit process
            foreach (var e in transition.Exit())
            {
                yield return e;
            }
            state.EndExit();

            // Switch state
            State = nextState;
            nextState = null;

            // Run the transition's enter process
            foreach (var e in transition.Enter())
            {
                yield return e;
            }
            transition = null;
            state.EndEnter();
        }
    }

    /// <summary>
    /// Set the current state, call its BeginEnter(), and listen for it to transition
    /// </summary>
    /// <value>The state to be the new current state</value>
    private IState State
    {
        set
        {
            state = value;
            state.OnBeginExit += HandleStateBeginExit;
            state.BeginEnter();
        }
    }

    /// <summary>
    /// Handles the current state wanting to transition
    /// </summary>
    /// <param name="sender">The state that wants to transition</param>
    /// <param name="e">Information about the desired transition</param>
    private void HandleStateBeginExit(object sender, StateBeginExitEventArgs e)
    {
        nextState = e.NextState;
        transition = e.Transition;
    }

    void Start()
    {
        var patrolState = new PatrolState();

        this.State = patrolState;

        StartCoroutine(this.Execute().GetEnumerator());
    }
}
