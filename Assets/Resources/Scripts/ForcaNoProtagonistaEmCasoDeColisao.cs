using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcaNoProtagonistaEmCasoDeColisao : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ControleDoPersonagem controle_do_personagem = other.GetComponent<ControleDoPersonagem>();
            if (controle_do_personagem == null) Debug.Log("Deu bug aqui.");

            controle_do_personagem.velx *= -1;
            controle_do_personagem.vely *= -1;
        }
    }
}
