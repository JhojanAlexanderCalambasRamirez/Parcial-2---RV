using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class PanelRegistroManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button botonIniciar;
    public GameObject panelMuseoInicio;

    private void Start()
    {
        botonIniciar.interactable = false; // Desactivar el botón al inicio
        inputField.onValueChanged.AddListener(ValidarNombre);
        botonIniciar.onClick.AddListener(IniciarExperiencia);
    }

    // Validar que el nombre tenga más de 4 caracteres
    private void ValidarNombre(string nombre)
    {
        botonIniciar.interactable = nombre.Length > 4;
    }

    // Iniciar la experiencia y guardar el nombre en JSON
    private void IniciarExperiencia()
    {
        string nombre = inputField.text;
        GuardarNombre(nombre);
        panelMuseoInicio.SetActive(true); // Muestra el PanelMuseoInicio
        gameObject.SetActive(false); // Oculta el PanelRegistro
    }

    // Guardar el nombre en un archivo JSON
    private void GuardarNombre(string nombre)
    {
        string path = Application.persistentDataPath + "/usuario.json";
        UsuarioData data = new UsuarioData { nombre = nombre };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    [System.Serializable]
    public class UsuarioData
    {
        public string nombre;
    }
}
