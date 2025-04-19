using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panelTextoInformativo;
    public TMP_Text contenidoTexto;
    public ScrollRect scrollRect;

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
}
