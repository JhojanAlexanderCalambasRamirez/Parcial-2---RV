using System;
using System.IO;
using UnityEngine;

[Serializable]
public class Usuario
{
    public string nombreUsuario;

    public Usuario(string nombre)
    {
        this.nombreUsuario = nombre;
    }
}

public class UsuarioManager : MonoBehaviour
{
    private string filePath;

    void Start()
    {
        // Especificamos el directorio y el nombre del archivo donde se guardará el JSON
        filePath = Application.persistentDataPath + "/usuario.json";

        // Si el archivo JSON ya existe, cargamos los datos
        if (File.Exists(filePath))
        {
            CargarUsuario();
        }
    }

    // Método para guardar el nombre del usuario en un archivo JSON
    public void GuardarUsuario(string nombre)
    {
        Usuario usuario = new Usuario(nombre);
        string json = JsonUtility.ToJson(usuario);
        File.WriteAllText(filePath, json); // Guardamos el JSON en el archivo
        Debug.Log("Nombre guardado en JSON: " + nombre);
    }

    // Método para cargar los datos del usuario desde el archivo JSON
    public void CargarUsuario()
    {
        string json = File.ReadAllText(filePath);
        Usuario usuario = JsonUtility.FromJson<Usuario>(json);
        Debug.Log("Nombre cargado desde JSON: " + usuario.nombreUsuario);
        // Aquí podrías pasar el nombre a donde lo necesites en tu juego, por ejemplo:
        PanelManager.Instance.SetNombreUsuario(usuario.nombreUsuario);
    }
}
