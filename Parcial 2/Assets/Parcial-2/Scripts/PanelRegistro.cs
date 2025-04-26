using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;


public class PanelRegistro : MonoBehaviour
{
    public TMP_InputField inputFieldNombre;
    public Button buttonRegistrarse;
    public Button buttonIniciarExperiencia;
    private string filePath = "Assets/Parcial-2/JSON/usuarios.json";
    private PanelManager panelManager;

    void Start()
    {
        panelManager = FindObjectOfType<PanelManager>();
        buttonRegistrarse.interactable = false;
        buttonIniciarExperiencia.interactable = false;

        inputFieldNombre.onValueChanged.AddListener(OnNameChanged);
        buttonRegistrarse.onClick.AddListener(RegistrarUsuario);
        buttonIniciarExperiencia.onClick.AddListener(IniciarExperiencia);
    }

    void OnNameChanged(string nombre)
    {
        if (nombre.Length >= 4)
        {
            buttonRegistrarse.interactable = true;
        }
        else
        {
            buttonRegistrarse.interactable = false;
        }
    }

    void RegistrarUsuario()
    {
        if (inputFieldNombre != null)
        {
            string nombreUsuario = inputFieldNombre.text;
            if (UsuarioManager.Instance != null)
            {
                UsuarioManager.Instance.GuardarUsuario(nombreUsuario, 0);  // Guardamos el nombre
            }
            else
            {
                Debug.LogError("UsuarioManager.Instance es nulo");
            }
        }
        else
        {
            Debug.LogError("El InputField no está asignado en el Inspector");
        }

        if (buttonIniciarExperiencia != null)
        {
            buttonIniciarExperiencia.interactable = true;
        }
        else
        {
            Debug.LogError("El botón Iniciar Experiencia no está asignado en el Inspector");
        }
    }


    void IniciarExperiencia()
    {
        // Aquí se podría cargar el siguiente panel
        Debug.Log("Iniciando experiencia");
        // PanelMuseoInicio.Instance.MostrarPanel();
        panelManager.IrAlPanelMuseoInicio();
    }
}
