using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script que regula de quanto em quanto tempo o Canhão vai atirar.
/// 
/// Ou seja, sem ele o canhão NÃO atira.
/// </summary>
public class DisparadorCronometrado : MonoBehaviour {

    public float segundos_entre_tiros = 1.0f;

    private float time_passed = 0.0f;
    private float start_time = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        time_passed += Time.time - start_time;
        start_time = Time.time;

        if (time_passed >= segundos_entre_tiros)
        {
            time_passed = 0.0f;
            GetComponent<Canhao>().Fogo();
        }

    }
}
