using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;  // Asegúrate de tener esta línea para usar Dictionary
using System.Linq; // Importa para usar ToArray

public class GuideManager : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    void Start()
    {
        keywords.Add("ayuda", ShowHelp);

        // Convertir las claves del diccionario a un arreglo usando ToArray
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if (keywords.ContainsKey(args.text))
        {
            keywords[args.text].Invoke();
        }
    }

    private void ShowHelp()
    {
        // Aquí se activan las acciones del guía cuando se reconoce "ayuda"
        Debug.Log("Guía de ayuda activada");
    }

    void OnDestroy()
    {
        keywordRecognizer.Stop();
        keywordRecognizer.Dispose();
    }
}
