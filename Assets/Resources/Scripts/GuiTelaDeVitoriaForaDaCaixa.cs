using Basicas_1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiTelaDeVitoriaForaDaCaixa : GuiPadrao2
{

    GUIStyle estilo_titulo_tela_de_vitoria_fora_da_caixa;
    GUIStyle estilo_botoes_tela_de_vitoria_fora_da_caixa;
    private int posicaox;
    private int qualbotao = -1;
    private int resultado = -1;
    private string[] toolbarStrings = { "Voltar à\n" + "Tela Inicial", "Jogar de\n" + "Novo", "Sair" };

    private bool creditos = false;

    // Use this for initialization
    void Start()
    {
        estilo_titulo_tela_de_vitoria_fora_da_caixa = new GUIStyle();
        estilo_titulo_tela_de_vitoria_fora_da_caixa.alignment = TextAnchor.MiddleCenter;
        estilo_titulo_tela_de_vitoria_fora_da_caixa.font = Font.CreateDynamicFontFromOSFont("Verdana", 40);

        estilo_botoes_tela_de_vitoria_fora_da_caixa = new GUIStyle("box");
        estilo_botoes_tela_de_vitoria_fora_da_caixa.alignment = TextAnchor.MiddleCenter;
        estilo_botoes_tela_de_vitoria_fora_da_caixa.font = Font.CreateDynamicFontFromOSFont("Verdana", 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnGUI()
    {
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));

        posicaox = 0;
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), string.Empty);
        GUI.Box(new Rect(Screen.width / 4, Screen.height / 6, Screen.width / 2, Screen.height / 2),
            "Você venceu por pensar fora da caixa! Continue assim :DDD", estilo_titulo_tela_de_vitoria_fora_da_caixa);

        resultado = GUI.Toolbar(new Rect(Screen.width / 12 * 3, Screen.height / 10 * 8,
                                        Screen.width / 12 * 6, Screen.height / 10), qualbotao,
                                toolbarStrings);

        switch (resultado)
        {
            //Vai para o pre-loading do FIT
            case 0:
                CarregaCena.Carrega((int)Cenas.Main_Menu);
                break;
            //Abre créditos
            case 1:
                CarregaCena.Carrega((int)Cenas.Main_GamePlay);
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

    }

}
