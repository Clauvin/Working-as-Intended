﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script que talvez vá pro Basicas... tem como funcao atirar (quando pedido por outro script) a municao guardada nele,
/// seja lá qual for...
/// </summary>
public class Canhao : MonoBehaviour {

    public float angulo = 0.0f;
    public float vel = -0.5f;
    public GameObject qual_municao = null;

    private GameObject instanciado;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fogo()
    {

        instanciado = Instantiate(qual_municao, this.transform.position, Quaternion.identity);
        instanciado.GetComponent<ControleAntagonistaLinhaReta>().velx = vel;

    }
}
