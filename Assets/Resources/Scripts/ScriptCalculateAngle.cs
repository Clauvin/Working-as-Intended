using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ScriptCalculateAngle : MonoBehaviour {

    GameObject atirador;
    GameObject protagonista;

    public Vector2 atirador_position;
    public Vector2 protagonista_position;
    public Vector2 third_point_position;

    public float angle;

	// Use this for initialization
	void Start () {
        atirador = GameObject.FindGameObjectWithTag("Atirador Móvel");
        protagonista = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        atirador_position.x = atirador.transform.position.x;
        atirador_position.y = atirador.transform.position.y;

        protagonista_position.x = protagonista.transform.position.x;
        protagonista_position.y = protagonista.transform.position.y;

        third_point_position.x = atirador_position.x;
        third_point_position.y = protagonista_position.y;

        angle = Vector2.SignedAngle(third_point_position, protagonista_position);

    }
}
