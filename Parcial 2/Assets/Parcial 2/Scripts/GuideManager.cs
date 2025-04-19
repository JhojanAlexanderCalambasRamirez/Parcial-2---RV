using UnityEngine;

public class GuideManager : MonoBehaviour
{
    public Animator[] animatorsGuia;

    public void ActivarGuia(int index)
    {
        for (int i = 0; i < animatorsGuia.Length; i++)
        {
            animatorsGuia[i].gameObject.SetActive(i == index);
        }

        if (animatorsGuia[index])
        {
            animatorsGuia[index].SetTrigger("Hablar"); // Idle + Talk alternos
        }
    }

    public void DesactivarTodos()
    {
        foreach (var a in animatorsGuia)
        {
            a.gameObject.SetActive(false);
        }
    }
}
