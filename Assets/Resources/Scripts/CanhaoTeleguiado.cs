using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhaoTeleguiado : MonoBehaviour {

    public float vel;
    public float nivel_de_previsao;
    private float angulo_em_graus;

    public GameObject qual_municao = null;
    

    private GameObject instanciado;
    

    private float vel_x = 0.0f;
    private float vel_y = 0.0f;

    public bool atirar = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Atirar();
	}

    public void Fogo()
    {
        MiraEmProtagonista();
        instanciado = Instantiate(qual_municao, this.transform.position, Quaternion.identity);
        instanciado.GetComponent<ControleAntagonistaLinhaReta>().velx =
            vel_x;
        instanciado.GetComponent<ControleAntagonistaLinhaReta>().vely =
            vel_y;
    }

    private void MiraEmProtagonista()
    {
        float pos_prot_x = GameObject.FindWithTag("Player").GetComponent<ControleDoPersonagem>().trab.x +
                            GameObject.FindWithTag("Player").GetComponent<ControleDoPersonagem>().velx * nivel_de_previsao;
        float pos_prot_y = GameObject.FindWithTag("Player").GetComponent<ControleDoPersonagem>().trab.y +
                            GameObject.FindWithTag("Player").GetComponent<ControleDoPersonagem>().vely * nivel_de_previsao;

        float cat_x = (this.transform.position.x - pos_prot_x) / 60.0f * -1;
        float cat_y = (this.transform.position.y - pos_prot_y) / 60.0f * -1;
        float hip = Mathf.Sqrt(cat_x * cat_x + cat_y * cat_y);
        vel_x = vel * (cat_x / hip);
        vel_y = vel * (cat_y / hip);
    }

    private void Atirar()
    {
        if (atirar)
        {
            Fogo();
            atirar = false;
        }
    }

}
