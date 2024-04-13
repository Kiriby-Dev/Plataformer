using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBase : MonoBehaviour
{
    [SerializeField] protected float saludInicial;
    [SerializeField] protected float saludMax;

    public float Salud { get; protected set; }
    private bool estaInmovilizado = false; // Variable de estado para controlar si el personaje est� inmovilizado

    public bool EstaInmovilizado => estaInmovilizado;

    // Tiempo de inmovilizaci�n despu�s de recibir da�o
    [SerializeField] private float tiempoInmovilizacion;
    private float tiempoInmovilizacionActual = 0f;

    protected virtual void Start()
    {
        Salud = saludInicial;
    }

    protected virtual void Update()
    {
        // Actualiza el tiempo de inmovilizaci�n actual
        if (tiempoInmovilizacionActual > 0f)
        {
            tiempoInmovilizacionActual -= Time.deltaTime;
            if (tiempoInmovilizacionActual <= 0f)
            {
                tiempoInmovilizacionActual = 0f;
                estaInmovilizado = false; // Reactiva la capacidad de movimiento
                InmovilizarPersonaje(false);
            }
        }
    }

    public void RecibirDa�o(float cantidad)
    {
        if (cantidad <= 0)
        {
            return;
        }

        if (Salud > 0 && !estaInmovilizado) // Verifica si el personaje no est� inmovilizado
        {
            Salud -= cantidad;
            ActualizarBarraVida(Salud, saludMax);
            PersonajeGolpeado();
            if (Salud <= 0f)
            {
                ActualizarBarraVida(Salud, saludMax);
                PersonajeDerrotado();
            }

            // Inmoviliza al personaje por el tiempo especificado
            estaInmovilizado = true;
            tiempoInmovilizacionActual = tiempoInmovilizacion;
            InmovilizarPersonaje(true);
        }
    }

    protected virtual void ActualizarBarraVida(float vidaActual, float vidaMax)
    {

    }

    protected virtual void PersonajeDerrotado()
    {

    }

    protected virtual void PersonajeGolpeado()
    {

    }

    protected virtual void InmovilizarPersonaje(bool valor) 
    {

    }
}
