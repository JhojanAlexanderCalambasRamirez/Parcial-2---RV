using UnityEngine;

public class ItemSizePulse : MonoBehaviour
{
    // Variables públicas para personalizar el comportamiento del item
    public float crecimientoEscala = 1.2f;  // Escala máxima que alcanzará el objeto (por ejemplo, 1.2 significa un 20% más grande)
    public float velocidadPulso = 1f;  // Velocidad con la que el objeto crece y decrece
    public bool pulsoContinuo = true;  // Si es verdadero, el objeto seguirá pulsando (creciendo y decreciendo), si es falso, hará un pulso único

    private Vector3 escalaOriginal;
    private bool creciendo = true;  // Si el objeto está creciendo o decreciendo

    void Start()
    {
        // Guardamos la escala original del objeto
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        if (pulsoContinuo)
        {
            // Hacer que el objeto crezca y decrezca continuamente
            PulseContinuo();
        }
        else
        {
            // Hacer que el objeto solo haga un pulso (crecer y luego decrecer)
            PulseUnaVez();
        }
    }

    // Función para hacer el pulso continuo (crecer y decrecer)
    private void PulseContinuo()
    {
        // Si estamos creciendo, aumentamos la escala
        if (creciendo)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, escalaOriginal * crecimientoEscala, Time.deltaTime * velocidadPulso);
        }
        else
        {
            // Si estamos decreciendo, regresamos a la escala original
            transform.localScale = Vector3.Lerp(transform.localScale, escalaOriginal, Time.deltaTime * velocidadPulso);
        }

        // Si el objeto alcanzó la escala máxima o la original, invertimos el proceso
        if (transform.localScale == escalaOriginal * crecimientoEscala)
        {
            creciendo = false;
        }
        else if (transform.localScale == escalaOriginal)
        {
            creciendo = true;
        }
    }

    // Función para hacer solo un pulso (crecer y luego decrecer)
    private void PulseUnaVez()
    {
        if (transform.localScale == escalaOriginal)
        {
            // Crecer hasta la escala máxima
            transform.localScale = Vector3.Lerp(transform.localScale, escalaOriginal * crecimientoEscala, Time.deltaTime * velocidadPulso);
        }
        else if (transform.localScale == escalaOriginal * crecimientoEscala)
        {
            // Decrecer hasta la escala original
            transform.localScale = Vector3.Lerp(transform.localScale, escalaOriginal, Time.deltaTime * velocidadPulso);
        }
    }
}
