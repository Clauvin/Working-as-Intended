﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basicas_1;

/// <summary>
/// Vinda do meu visualizador de logs para talvez integrar a Básicas no futuro, a GuiMenuInicial
/// usa GuiStyle e Guis de desenvolvedor para criar interfaces gráficas minimamente atraentes.
/// </summary>

public class GuiMenuInicial : GuiPadrao2 {

    GUIStyle estilotitulotelainicial;
    GUIStyle estilobotoestelainicial;
    private int posicaox;
    private int qualbotao = -1;
    private int resultado = -1;
    private string[] toolbarStrings = { "Visualizar Log F!T", "Créditos", "Sair" };

    private bool creditos = false;

    // Use this for initialization
    void Start()
    {
        estilotitulotelainicial = new GUIStyle();
        estilotitulotelainicial.alignment = TextAnchor.MiddleCenter;
        estilotitulotelainicial.font = Font.CreateDynamicFontFromOSFont("Verdana", 40);

        estilobotoestelainicial = new GUIStyle("box");
        estilobotoestelainicial.alignment = TextAnchor.MiddleCenter;
        estilobotoestelainicial.font = Font.CreateDynamicFontFromOSFont("Verdana", 10);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public override void OnGUI()
    {
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));

        posicaox = 0;
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), string.Empty);
        GUI.Box(new Rect(Screen.width / 4, Screen.height / 6, Screen.width / 2, Screen.height / 2),
            "Visualizador de Logs\n\n" + "F!T\n\n" + "1.0.1-beta", estilotitulotelainicial);

        resultado = GUI.Toolbar(new Rect(Screen.width / 12 * 3, Screen.height / 10 * 8,
                                        Screen.width / 12 * 6, Screen.height / 10), qualbotao,
                                toolbarStrings);

        switch (resultado)
        {
            //Vai para o pre-loading do FIT
            case 0:
                CarregaCena.Carrega((int)Cenas.Main_GamePlay);
                break;
            //Abre créditos
            case 1:
                creditos = true;
                break;
            //Fecha o programa
            case 2:
                Application.Quit();
                break;
            default:
                break;
        }

        resultado = -1;

        GUI.EndGroup();

        if (creditos)
        {
            GUI.BeginGroup(new Rect(Screen.width * 0.4f, Screen.height / 4, Screen.width * 0.2f, Screen.height * 0.3f));

            GUI.Box(new Rect(0, 0, Screen.width * 0.2f, Screen.height * 0.3f), "Créditos\n\n" +
                "Cláuvin Erlan José\n da Costa Curty de Almeida\n" +
                "(clauvin_almeida@hotmail.com)\n" +
                "Contribuidor: Bruno Correia\n" +
                "(acrescentar e-mail de Bruno Correia).");

            if (GUI.Button(new Rect(Screen.width * 0.05f, Screen.height * 0.25f, Screen.width * 0.1f, Screen.height * 0.05f),
                "Fechar"))
            {

                creditos = false;

            }

            GUI.EndGroup();
        }
    }

}