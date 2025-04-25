using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Usuario
{
    public string nombreUsuario;
    public int puntaje;
}

[System.Serializable]
public class UsuarioList
{
    public List<Usuario> usuarios;
}

public class UsuarioManager : MonoBehaviour
{
    public static UsuarioManager Instance;
    public static string nombreUsuarioActual;  // Nueva variable estática para almacenar el nombre del usuario actual
    private string filePath = "Assets/Parcial-2/JSON/usuarios.json";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GuardarUsuario(string nombreUsuario, int puntaje)
    {
        nombreUsuarioActual = nombreUsuario;  // Guardamos el nombre del usuario actual
        Usuario nuevoUsuario = new Usuario { nombreUsuario = nombreUsuario, puntaje = puntaje };
        UsuarioList usuarioList = CargarUsuarios();

        // Verificar si el usuario ya existe, si es así, actualizamos su puntaje
        bool usuarioExistente = false;
        foreach (Usuario usuario in usuarioList.usuarios)
        {
            if (usuario.nombreUsuario == nombreUsuario)
            {
                usuario.puntaje = puntaje;
                usuarioExistente = true;
                break;
            }
        }

        // Si no existe, lo agregamos como nuevo usuario
        if (!usuarioExistente)
        {
            usuarioList.usuarios.Add(nuevoUsuario);
        }

        string json = JsonUtility.ToJson(usuarioList, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Usuario guardado: " + nombreUsuario + " Puntaje: " + puntaje);
    }

    public UsuarioList CargarUsuarios()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<UsuarioList>(json);
        }
        else
        {
            return new UsuarioList { usuarios = new List<Usuario>() };
        }
    }
}
