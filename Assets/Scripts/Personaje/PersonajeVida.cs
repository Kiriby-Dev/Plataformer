using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PersonajeVida : VidaBase
{
    public static Action EventoPersonajeDerrotado;
    public static Action EventoPersonajeDañado;
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

    protected override void Update()
    {
        base.Update();
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

    protected override void PersonajeGolpeado()
    {
        EventoPersonajeDañado?.Invoke();
    }

    protected override void InmovilizarPersonaje(bool valor)
    {
        rigidbody2.velocity = Vector2.zero;
        rigidbody2.GetComponent<PersonajeMovimiento>().enabled = !valor;
        rigidbody2.GetComponent<PersonajeAtaque>().enabled = !valor;
    }

    protected override void ActualizarBarraVida(float vidaActual, float vidaMax)
    {
        UIManager.Instance.ActualizarVidaPersonaje(vidaActual, vidaMax);
    }
}
