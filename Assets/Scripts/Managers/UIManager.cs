using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Configuracion")]
    [SerializeField] private Image vidaPlayer;

    private float vidaActual;
    private float vidaMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarUIPersonaje();
    }

    private void ActualizarUIPersonaje() 
    {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount, vidaActual / vidaMax, 10f * Time.deltaTime);
    }

    public void ActualizarVidaPersonaje(float pVidaActual, float pVidaMax) 
    {
        vidaActual = pVidaActual;
        vidaMax = pVidaMax;
    }
}
