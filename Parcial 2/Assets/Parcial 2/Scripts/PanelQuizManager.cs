using UnityEngine;
using UnityEngine.UI;

public class PanelQuizManager : MonoBehaviour
{
    public Text[] preguntasText;
    public Button[] respuestaButtons;
    public string[] respuestasCorrectas;

    private void Start()
    {
        for (int i = 0; i < respuestaButtons.Length; i++)
        {
            int index = i;
            respuestaButtons[i].onClick.AddListener(() => VerificarRespuesta(index));
        }
    }

    // Función para verificar la respuesta seleccionada
    private void VerificarRespuesta(int index)
    {
        if (respuestasCorrectas[index] == "Correcta")  // Ajusta esta lógica según tus respuestas
        {
            Debug.Log("Respuesta correcta");
        }
        else
        {
            Debug.Log("Respuesta incorrecta");
        }
    }
}
