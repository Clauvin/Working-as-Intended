using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRotationsInSpace : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rotation(1f);
	}

    public void Rotation(float change_in_angle)
    {
        GetComponent<RectTransform>().Rotate(new Vector3(0.0f, 0.0f, change_in_angle));
    }
}
