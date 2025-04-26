using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PanelResultados : MonoBehaviour
{
    public TMP_Text TMP_Text_ResultadosQuiz;
    public Button botonFinalizar;

    public static PanelResultados Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        botonFinalizar.onClick.AddListener(Finalizar);
        MostrarResultados();
    }

    public void MostrarResultados()
    {
        UsuarioList usuarios = UsuarioManager.Instance.CargarUsuarios();

        var usuarioActual = usuarios.usuarios.FirstOrDefault(u => u.nombreUsuario == UsuarioManager.nombreUsuarioActual);
        int puntajeActual = usuarioActual != null ? usuarioActual.puntaje : 0;

        var usuariosOrdenados = usuarios.usuarios
            .OrderByDescending(u => u.puntaje)
            .ThenBy(u => u.nombreUsuario)
            .ToList();

        TMP_Text_ResultadosQuiz.text = "";

        foreach (var usuario in usuariosOrdenados)
        {
            if (usuario.nombreUsuario == UsuarioManager.nombreUsuarioActual)
            {
                TMP_Text_ResultadosQuiz.text += $"<color=green><b>{usuario.nombreUsuario} - Puntaje: {usuario.puntaje}</b></color>\n";
            }
            else
            {
                TMP_Text_ResultadosQuiz.text += $"{usuario.nombreUsuario} - Puntaje: {usuario.puntaje}\n";
            }
        }
    }


    void Finalizar()
    {
        Debug.Log("Reiniciando para nuevo usuario...");
        PanelManager.Instance.IrAlPanelRegistro();
    }
}
