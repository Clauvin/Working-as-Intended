using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMLibrary;
using System;

public class AimingState : MonoBehaviour, IState {

    int percepcao;
    int percepcao_maxima_em_frames = 1*60;

    float rotation_step = 0.5f;
    float actual_rotation = 0.0f;
    float minimum_rotation_step = -15f;
    float maximum_rotation_step = 15f;

    private ScriptRotationsInSpace rotations_in_space;
    private ScriptSensesProtagonist protagonist_senser;

    /// <summary>
    /// Notify the state that the transition process has begun the entering phase
    /// </summary>
    public void BeginEnter()
    {
        percepcao = 0;
        rotations_in_space = GameObject.FindGameObjectWithTag("Atirador Móvel").transform.
            GetComponentInChildren<ScriptRotationsInSpace>();
        protagonist_senser = GameObject.FindGameObjectWithTag("Atirador Móvel").transform.
            GetComponentInChildren<ScriptSensesProtagonist>();
    }

    /// <summary>
    /// Notify the state that the transition process has finished the entering phase
    /// </summary>
    public void EndEnter() {



    }

    /// <summary>
    /// Execute the state's logic over time. This function should 'yield return' until it has
    /// nothing left to do. It may also dispatch OnBeginExit when it is ready to begin transitioning
    /// to the next state. If it does this, this funtion will no longer be resumed.
    /// </summary>
    public IEnumerable Execute()
    {
        while (true)
        {
            if (protagonist_senser.senses_protagonist)
            {
                percepcao += 10;
            } else {
                percepcao--;
                actual_rotation += rotation_step;
                rotations_in_space.Rotation(rotation_step);
                if (actual_rotation > maximum_rotation_step) rotation_step *= -1;
                if (actual_rotation < minimum_rotation_step) rotation_step *= -1;
            }
            if (percepcao >= percepcao_maxima_em_frames)
            {
                var nextState = new ShootState();
                var transition = new ScriptAimingShootTransition();
                var eventArgs = new StateBeginExitEventArgs(nextState, transition);
                OnBeginExit(this, eventArgs);
            } else if (percepcao < 0)
            {
                rotations_in_space.Rotation(-actual_rotation);

                var nextState = new PatrolState();
                var transition = new ScriptAimingPatrolTransition();
                var eventArgs = new StateBeginExitEventArgs(nextState, transition);
                OnBeginExit(this, eventArgs);
            }
            yield return 0;
        }
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
