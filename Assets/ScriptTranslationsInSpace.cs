using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTranslationsInSpace : MonoBehaviour {

    public float left_x_limit = -28.0f;
    public float right_x_limit = 28.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Translation(-1f, 0, 0);
	}

    public void Translation(float change_in_x, float change_in_y, float change_in_z)
    {
        Vector3 old_position = GetComponent<RectTransform>().position;
        Vector3 new_position = old_position + new Vector3(change_in_x, change_in_y, change_in_z);

        if (new_position.x < left_x_limit) new_position.x = left_x_limit;
        if (new_position.x > right_x_limit) new_position.x = right_x_limit;

        GetComponent<RectTransform>().position = new_position;
    }
}
