using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mais um script candidato a ser companhia da Basicas,
/// ele ativa e desativa objetos filhos, o que neste jogo vai ser útil para
/// lidar com múltiplos atiradores.
/// </summary>
public class AtivadorEDesativador : MonoBehaviour {

    public int tempo_para_ativacao;
    public int tempo_para_desativacao;

    private bool foi_ativado = false;
    private bool foi_desativado = false;
    private Timer timer_do_jogo = null;
    private Transform[] children;

    void Awake()
    {
        timer_do_jogo = FindObjectOfType<Timer>();
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if ((timer_do_jogo.tempo == tempo_para_ativacao) && (foi_ativado == false))
        {
            //GetComponentsInChildren<Transform>(true);
            //a função ser chamada com true faz com que os inativos sejam colocados no array também.
            children = GetComponentsInChildren<Transform>(true);
            foreach (Transform a in children)
            {
                //the if is needed since in Unity 5.5, GetComponentsInChildren ALSO
                //gets the Component of the script that called for the function.
                if (a.gameObject != this.gameObject) a.gameObject.SetActive(true);
            }
            foi_ativado = true;

        }

        if ((timer_do_jogo.tempo == tempo_para_desativacao) && (foi_desativado == false))
        {

            children = GetComponentsInChildren<Transform>();
            foreach (Transform a in children)
            {
                //the if is needed since in Unity 5.5, GetComponentsInChildren ALSO
                //gets the Component of the script that called for the function.
                if (a.gameObject != this.gameObject) a.gameObject.SetActive(false);
            }
            foi_desativado = true;

        }

    }
}
