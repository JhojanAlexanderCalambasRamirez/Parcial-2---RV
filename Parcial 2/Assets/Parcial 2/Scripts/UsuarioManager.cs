using UnityEngine;
using TMPro;
using System.IO;
using System;
using System.Collections.Generic;

public class UsuarioManager : MonoBehaviour
{
    public static UsuarioManager Instance;
    private string filePath;
    private string jsonUsuarios;

    public TMP_Text TMP_Text_ResultadosQuiz;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Asegurarse de que no se destruya entre escenas
        }
        else
        {
            Destroy(gameObject);  // Si ya existe una instancia, destrúyela
        }
    }

    void Start()
    {
        filePath = Application.dataPath + "/Parcial 2/JSON/usuarios.json"; // Ruta de guardado
        Debug.Log("Ruta donde se guarda el archivo JSON: " + filePath);

        if (File.Exists(filePath))
        {
            CargarUsuarios();
        }
        else
        {
            GuardarUsuarios(new Usuario("Invitado", 0)); // Si no existe, se guarda un usuario por defecto
        }
    }

    // Función para guardar usuarios y puntajes
    public void GuardarUsuarios(Usuario usuario)
    {
        List<Usuario> usuarios;

        if (File.Exists(filePath))
        {
            jsonUsuarios = File.ReadAllText(filePath); // Leemos el contenido del archivo
            usuarios = JsonUtility.FromJson<UsuarioList>(jsonUsuarios).usuarios; // Deserializamos los usuarios

            // Verificar si el usuario ya existe y actualizar su puntaje
            bool usuarioExistente = false;
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].nombreUsuario == usuario.nombreUsuario)
                {
                    usuarios[i].puntaje = usuario.puntaje; // Solo actualizar el puntaje del usuario actual
                    usuarioExistente = true;
                    break;
                }
            }

            // Si el usuario no existe, lo agregamos con su puntaje
            if (!usuarioExistente)
            {
                usuarios.Add(usuario);
            }
        }
        else
        {
            usuarios = new List<Usuario>(); // Si el archivo no existe, iniciamos una lista vacía
        }

        // Convertimos la lista de usuarios a formato JSON
        UsuarioList usuarioList = new UsuarioList { usuarios = usuarios };
        jsonUsuarios = JsonUtility.ToJson(usuarioList, true);

        // Guardamos en el archivo JSON
        File.WriteAllText(filePath, jsonUsuarios);

        Debug.Log("Usuario guardado en JSON: " + usuario.nombreUsuario);
    }

    // Función para cargar los usuarios y mostrar los puntajes en TMP_Text
    public void CargarUsuarios()
    {
        if (File.Exists(filePath))
        {
            jsonUsuarios = File.ReadAllText(filePath); // Leemos el contenido del archivo
            UsuarioList usuarioList = JsonUtility.FromJson<UsuarioList>(jsonUsuarios); // Deserializamos

            TMP_Text_ResultadosQuiz.text = "Ranking:\n";

            // Recorrer todos los usuarios y mostrarlos en el texto
            foreach (var usuario in usuarioList.usuarios)
            {
                TMP_Text_ResultadosQuiz.text += $"{usuario.nombreUsuario} - Puntaje: {usuario.puntaje}\n";
            }

            Debug.Log("Usuarios cargados desde JSON");
        }
        else
        {
            Debug.LogError("No se encontró el archivo de usuarios.");
        }
    }

    [Serializable]
    public class UsuarioList
    {
        public List<Usuario> usuarios;  // Lista de usuarios
    }

    [Serializable]
    public class Usuario
    {
        public string nombreUsuario;
        public int puntaje;

        public Usuario(string nombre, int puntaje)
        {
            this.nombreUsuario = nombre;
            this.puntaje = puntaje;
        }
    }
}
