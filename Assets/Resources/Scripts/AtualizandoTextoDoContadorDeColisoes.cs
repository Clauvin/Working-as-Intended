using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtualizandoTextoDoContadorDeColisoes : MonoBehaviour {

    private string colisoes;
    public string texto_inicial = "Colisões = ";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        colisoes = texto_inicial + FindObjectOfType<ControleDoPersonagem>().contador_de_acertos_recebidos;
        GetComponent<Text>().text = colisoes;

    }
}
