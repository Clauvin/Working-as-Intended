using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basicas_1;

public class GerenteDeEventos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKeyDown(KeyCode.P))
        {
            Reset.Resetar((int)Cenas.Main_GamePlay);
        }
        	
	}
}
