using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basicas_1;

public class VitoriaPorPensarForaDaCaixa : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") CarregaCena.Carrega((int)Cenas.Victory_For_Lateral_Thinking);
    }

}
