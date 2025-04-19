using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public void ReproducirAudio(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    public void DetenerAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void ReproducirSonidoBoton(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
