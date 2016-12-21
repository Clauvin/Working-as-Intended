using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAntagonistaLinhaReta : MonoBehaviour {

    public float accmodx = 0.00f;
    public float accmody = 0.00f;
    public float velx = 0.0f;
    public float vely = 0.0f;
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

        Debug.Log("1 - " + transform.position.x + " " + transform.position.y);
        trab = GetComponent<Transform>().position;
        posx = trab.x;
        posy = trab.y;
        Debug.Log("2 - " + transform.position.x + " " + transform.position.y);

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

        //Altera valor de X e Y da posição.
        trab.x = posx;
        trab.y = posy;
        GetComponent<Transform>().position = trab;

    }
}
