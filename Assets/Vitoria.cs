using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basicas_1;

public class Vitoria : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Timer>().tempo <= 64) CarregaCena.Carrega((int)Cenas.Victory_Screen);
	}
}
