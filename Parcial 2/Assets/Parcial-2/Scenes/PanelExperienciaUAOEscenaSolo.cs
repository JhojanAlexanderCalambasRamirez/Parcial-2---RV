using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelExperienciaPiezas : MonoBehaviour
{
    public Button piezas_buttonSiguiente;
    public Button piezas_buttonAnterior;
    public TMP_Text piezas_textoTitulo;
    public TMP_Text piezas_textoDescripcion;
    public TMP_Text piezas_textoProgreso;
    public GameObject[] piezas_modelos;

    public string[] piezas_titulos;
    public string[] piezas_descripciones;

    private int piezas_indiceActual = 0;
    private int piezas_total;

    void Start()
    {
        piezas_total = piezas_modelos.Length;

        piezas_buttonSiguiente.onClick.AddListener(VerSiguientePieza);
        piezas_buttonAnterior.onClick.AddListener(VerPiezaAnterior);

        MostrarPieza(piezas_indiceActual);
    }

    void VerSiguientePieza()
    {
        if (piezas_indiceActual < piezas_total - 1)
        {
            piezas_indiceActual++;
            MostrarPieza(piezas_indiceActual);
        }
    }

    void VerPiezaAnterior()
    {
        if (piezas_indiceActual > 0)
        {
            piezas_indiceActual--;
            MostrarPieza(piezas_indiceActual);
        }
    }

    void MostrarPieza(int indice)
    {
        if (indice < piezas_titulos.Length && indice < piezas_descripciones.Length)
        {
            piezas_textoTitulo.text = piezas_titulos[indice];
            piezas_textoDescripcion.text = piezas_descripciones[indice];
            piezas_textoProgreso.text = (indice + 1) + "/" + piezas_total;

            for (int i = 0; i < piezas_modelos.Length; i++)
            {
                piezas_modelos[i].SetActive(i == indice);
            }

            Debug.Log("Mostrando pieza " + (indice + 1) + " de " + piezas_total);
        }
        else
        {
            Debug.LogError("Índice fuera de rango para piezas_titulos o piezas_descripciones.");
        }
    }
}
