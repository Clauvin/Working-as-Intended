using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMLibrary;
using System;

public class PatrolState : MonoBehaviour, IState {

    public enum Direcoes
    {
        Esquerda = 0, Direita = 1
    }

    public Direcoes qual_direcao;

    private ScriptTranslationsInSpace translations_in_space;
    private ScriptSensesProtagonist protagonist_senser;

    /// <summary>
    /// Notify the state that the transition process has begun the entering phase
    /// </summary>
    public void BeginEnter() {

        translations_in_space = transform.GetComponentInParent<ScriptTranslationsInSpace>();
        float x = translations_in_space.transform.position.x;

        if (x < (translations_in_space.left_x_limit + translations_in_space.right_x_limit) / 2)
        {
            qual_direcao = Direcoes.Direita;
        } else { qual_direcao = Direcoes.Esquerda; }

        protagonist_senser = transform.GetComponentInParent<ScriptSensesProtagonist>();
    }

    /// <summary>
    /// Notify the state that the transition process has finished the entering phase
    /// </summary>
    public void EndEnter() { }

    /// <summary>
    /// Execute the state's logic over time. This function should 'yield return' until it has
    /// nothing left to do. It may also dispatch OnBeginExit when it is ready to begin transitioning
    /// to the next state. If it does this, this funtion will no longer be resumed.
    /// </summary>
    public IEnumerable Execute() {

        while (true)
        {
            if (qual_direcao == Direcoes.Esquerda) {
                translations_in_space.Translation(-0.3f, 0.0f, 0.0f);
            } else
            {
                translations_in_space.Translation(0.3f, 0.0f, 0.0f);
            }
            if (translations_in_space.transform.position.x <= translations_in_space.left_x_limit)
            {
                qual_direcao = Direcoes.Direita;
            }
            if (translations_in_space.transform.position.x >= translations_in_space.right_x_limit)
            {
                qual_direcao = Direcoes.Esquerda;
            }
            if (protagonist_senser.senses_protagonist) //Adicionar detecção de protagonista aqui
            {
                //começar transição para AimingState
            }
            yield return null;
        }

    }

    /// <summary>
    /// Dispatched when the state is ready to begin transitioning to the next state. This implies
    /// that the transition process will immediately begin the exiting phase.
    /// </summary>
    event EventHandler<StateBeginExitEventArgs> OnBeginExit;

    /// <summary>
    /// Notify the state that the transition process has finished exiting phase.
    /// </summary>
    public void EndExit() {
    
    }

}
