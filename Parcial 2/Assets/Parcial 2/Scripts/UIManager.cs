using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panelTextoInformativo;
    public TMP_Text contenidoTexto;
    public ScrollRect scrollRect;
    public TMP_Text tituloPieza;  // Agregamos un campo para el título

    public void MostrarTexto(string texto)
    {
        contenidoTexto.text = texto;
        panelTextoInformativo.SetActive(true);
        scrollRect.verticalNormalizedPosition = 1f; // Scroll arriba
    }

    public void OcultarTexto()
    {
        panelTextoInformativo.SetActive(false);
    }

    // Método para mostrar el título de la pieza
    public void MostrarTitulo(string titulo)
    {
        if (tituloPieza != null)
        {
            tituloPieza.text = titulo;
            tituloPieza.gameObject.SetActive(true); // Mostrar el título
        }
    }

    // Método para ocultar el título de la pieza
    public void OcultarTitulo()
    {
        if (tituloPieza != null)
        {
            tituloPieza.gameObject.SetActive(false); // Ocultar el título
        }
    }
}
