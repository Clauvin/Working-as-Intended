using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAntagonistaLinhaReta : MonoBehaviour {

    public float accmodx = 0.00f;
    public float accmody = 0.00f;
    public float velx = 0.0f;
    public float vely = 0.0f;
    public float distancia_a_ser_percorrida_para_desaparecer = 100.0f;
    public float distancia_percorrida = 0.0f;

    private float posx = 0.0f;
    private float posy = 0.0f;

    public Vector2 trab;

    ControleAntagonistaLinhaReta(float pos_x, float pos_y)
    {
        trab = GetComponent<Transform>().position;
        trab.x = pos_x;
        trab.y = pos_y;
        GetComponent<Transform>().position = trab;
    }

    // Use this for initialization
    void Start () {

        trab = GetComponent<Transform>().position;
        posx = trab.x;
        posy = trab.y;

    }
	
	// Update is called once per frame
	void Update () {

        //Recebe Input
        //Altera valor de Acc
        velx += accmodx;
        vely += accmody;

        //Altera valor de vel
        posx += velx;
        posy += vely;

        //Calcula a distancia percorrida pelo projétil
        distancia_percorrida += Mathf.Sqrt((trab.x - posx) * (trab.x - posx) + (trab.y - posy) * (trab.y - posy));

        //Altera valor de X e Y da posição.
        trab.x = posx;
        trab.y = posy;
        GetComponent<Transform>().position = trab;

        if (distancia_percorrida >= distancia_a_ser_percorrida_para_desaparecer) Destroy(gameObject);

    }
}
