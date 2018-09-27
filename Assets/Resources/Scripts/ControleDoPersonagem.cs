using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basicas_1;

public class ControleDoPersonagem : MonoBehaviour {

    public float velx = 0.0f;
    public float vely = 0.0f;
    public float posx = 0.0f;
    public float posy = 0.0f;

    public float accmodx = 0.01f;
    public float accmody = 0.01f;

    public bool a = false;
    public bool w = false;
    public bool s = false;
    public bool d = false;

    public Vector2 trab;

    public int contador_de_acertos_recebidos = 0;

    // Use this for initialization
    void Start () {
        trab = GetComponent<Transform>().position;
    }
	
	// Update is called once per frame
	void Update () {
		
        //Recebe Input
        //Altera valor de Acc

        if (Input.GetAxis("Horizontal") < 0.0f) { a = true; } 
        if (Input.GetAxis("Horizontal") > 0.0f) { d = true; }

        if (Input.GetAxis("Vertical") < 0.0f) { s = true; }
        if (Input.GetAxis("Vertical") > 0.0f) { w = true; }

        if (a)
        {
            velx -= accmodx;
            //Impede que, uma vez que o protagonista comece a se mover, volte a ficar parado
            // por ação do jogador.
            if (velx == 0.0f) velx -= accmodx;
        }
        if (w)
        {
            vely += accmody;
            //Impede que, uma vez que o protagonista comece a se mover, volte a ficar parado
            // por ação do jogador.
            if (vely == 0.0f) vely += accmody;
        }
        if (s)
        {
            vely -= accmody;
            //Impede que, uma vez que o protagonista comece a se mover, volte a ficar parado
            // por ação do jogador.
            if (vely == 0.0f) vely -= accmody;
        }
        if (d)
        {
            velx += accmodx;
            //Impede que, uma vez que o protagonista comece a se mover, volte a ficar parado
            // por ação do jogador.
            if (velx == 0.0f) velx += accmodx;
        }

        //Altera valor de vel
        posx += velx;
        posy += vely;

        //Altera valor de X e Y da posição.
        trab.x = posx;
        trab.y = posy;
        GetComponent<Transform>().position = trab;

        //Reseta booleans
        a = false; w = false; s = false; d = false;


    }

    //Quando houver colisão com algum objeto que dispare um Trigger...
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Antagonista") {
            contador_de_acertos_recebidos++;   
        }
    }
}
