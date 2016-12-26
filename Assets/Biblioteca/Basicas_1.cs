using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Biblioteca para prototipagem rápida na Unity.
/// 
/// Versão 1, criada para uso no jogo 1, "Working As Intended".
/// </summary>
namespace Basicas_1
{
    /// <summary>
    /// Classe Reset.
    /// 
    /// Responsável por carregar cenas, recarregando uma cena específica.
    /// </summary>
    public static class CarregaCena
    {
        public static void Carrega(int cena)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(cena);
        }
    }

    /// <summary>
    /// Classe Conversoes.
    /// 
    /// Responsável por conversões de valores para outros valores.
    /// </summary>

    public static class Conversoes
    {

        public static float DeGrauParaRadiano(float grau)
        {
            return grau * Mathf.PI / 180;
        }

        public static float DeRadianoParaGrau(float radiano)
        {
            return radiano * 180 / Mathf.PI;
        }
    }

    public enum Cenas
    {
        Main_Menu = 0,
        Main_GamePlay = 1
    }
}


