using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PersonajeVida : VidaBase
{
    public static Action EventoPersonajeDerrotado;
    Rigidbody2D rigidbody2;
   
    public bool PuedeSerCurado => Salud < saludMax;

    private void Awake()
    {
        rigidbody2 = gameObject.GetComponent<Rigidbody2D>();
    }
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
            rigidbody2.velocity = new Vector2 (0,rigidbody2.velocity.y);
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
