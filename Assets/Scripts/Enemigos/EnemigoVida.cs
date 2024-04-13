using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVida : VidaBase
{
    public Action EventoEnemigoDerrotado;
    public Action EventoEnemigoDañado;
    private Rigidbody2D rigidbody2;

    private void Awake()
    {
        rigidbody2 = gameObject.GetComponent<Rigidbody2D>();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (Salud <= 0)
        {
            rigidbody2.velocity = new Vector2(0, rigidbody2.velocity.y);
        }
        else 
        {
            base.Update();
        }
    }

    protected override void PersonajeDerrotado()
    {
        EventoEnemigoDerrotado?.Invoke();
    }

    protected override void PersonajeGolpeado()
    {
        EventoEnemigoDañado?.Invoke();
    }

    protected override void InmovilizarPersonaje(bool valor)
    {
        rigidbody2.velocity = Vector2.zero;
    }
}
