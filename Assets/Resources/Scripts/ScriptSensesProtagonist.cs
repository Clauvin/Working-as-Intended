using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSensesProtagonist : MonoBehaviour {

    public bool senses_protagonist = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") senses_protagonist = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player") senses_protagonist = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") senses_protagonist = false;
    }
}
