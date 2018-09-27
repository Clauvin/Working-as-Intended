using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtualizandoTextoDoTimer : MonoBehaviour {

    private string tempo;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        tempo = (GetComponent<Timer>().tempo - 65).ToString();
        GetComponent<Text>().text = tempo;
    }
}
