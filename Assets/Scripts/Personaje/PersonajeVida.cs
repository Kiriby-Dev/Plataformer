using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PersonajeVida : VidaBase
{
    public static Action EventoPersonajeDerrotado;
    public bool PuedeSerCurado => Salud < saludMax;

    protected override void Start()
    {
        base.Start();
        ActualizarBarraVida(Salud, saludMax);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            RecibirDaño(10);
        }

        if (Input.GetKeyDown(KeyCode.Y)) 
        {
            RestaurarSalud(10);
        }
        if (Salud <= 0)
        {
            gameObject.GetComponent<PersonajeMovimiento>().enabled = false;
        }
    }

    public void RestaurarSalud(float cantidad) 
    {
        if (PuedeSerCurado) 
        {
            Salud += cantidad;
            if (Salud > saludMax) 
            {
                Salud = saludMax;
            }
            ActualizarBarraVida(Salud, saludMax);
        }
    }

    protected override void PersonajeDerrotado()
    {
        EventoPersonajeDerrotado?.Invoke();
    }

    protected override void ActualizarBarraVida(float vidaActual, float vidaMax)
    {
        UIManager.Instance.ActualizarVidaPersonaje(vidaActual, vidaMax);
    }
}
