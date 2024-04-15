using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonido : Singleton<ControladorSonido>
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void EjecutarSonido(AudioClip sonido) 
    {
        audioSource.PlayOneShot(sonido);
    }

    public bool EnReproduccion(AudioSource audio) 
    {
        return audio.isPlaying;
    }
}
