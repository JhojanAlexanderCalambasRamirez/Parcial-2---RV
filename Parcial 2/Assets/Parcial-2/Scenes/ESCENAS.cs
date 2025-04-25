using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCENAS : MonoBehaviour
{
    // Índice de la escena que quieres cargar
    public int sceneIndexToLoad;

    // Este método lo llamaremos desde el botón
    public void LoadSceneByIndex()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}
