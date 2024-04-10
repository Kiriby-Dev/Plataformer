using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TiposDeAtaque 
{
    Melee,
    Rango
}

public class IAController : MonoBehaviour
{
    [Header("Estados")]
    [SerializeField] private IAEstado estadoInicial;
    [SerializeField] private IAEstado estadoDefault;

    [Header("Configuracion")]
    [SerializeField] private float rangoDeteccion;
    [SerializeField] private float rangoDeAtaque;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private LayerMask personajeLayerMask;

    [Header("Ataque")]
    [SerializeField] private float daño;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private TiposDeAtaque tipoAtaque;

    [Header("Debug")]
    [SerializeField] private bool mostrarDeteccion;
    [SerializeField] private bool mostrarRangoAtaque;

    private float tiempoParaSiguienteAtaque;

    public Transform PersonajeReferencia { get; set; }
    public IAEstado EstadoActual { get; set; }
    public float RangoDeteccion => rangoDeteccion;
    public float RangoDeAtaque => rangoDeAtaque;
    public float VelocidadMovimiento => velocidadMovimiento;
    public float Daño => daño;
    public TiposDeAtaque TipoAtaque => tipoAtaque;
    public LayerMask PersonajeLayerMask => personajeLayerMask;

    private void Start()
    {
        EstadoActual = estadoInicial;
    }

    private void Update()
    {
        EstadoActual.EjecutarEstado(this);
    }

    public void CambiarEstado(IAEstado nuevoEstado) 
    {
        if (nuevoEstado != estadoDefault) 
        {
            EstadoActual = nuevoEstado;
        }
    }

    public void AtaqueMelee(float cantidad) 
    {
        if (PersonajeReferencia != null) 
        {
            AplicarDañoAlPersonaje(cantidad);
        }
    }

    public void AplicarDañoAlPersonaje(float cantidad) 
    {
        PersonajeReferencia.GetComponent<PersonajeVida>().RecibirDaño(cantidad);
    }

    public bool PersonajeEnRangoDeAtaque(float rango) 
    {
        float distanciaHaciaPersonaje = (PersonajeReferencia.position - transform.position).sqrMagnitude;
        if (distanciaHaciaPersonaje < Mathf.Pow(rango, 2)) 
        {
            return true;
        }
        return false;
    }

    public bool EsTiempoDeAtacar() 
    {
        if (Time.time > tiempoParaSiguienteAtaque) 
        {
            return true;
        }
        return false;
    }

    public void ActualizarTiempoEntreAtaques() 
    {
        tiempoParaSiguienteAtaque = Time.time + tiempoEntreAtaques;
    }

    private void OnDrawGizmos()
    {
        if (mostrarDeteccion) 
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
        }

        if (mostrarRangoAtaque)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, rangoDeAtaque);
        }
    }
}
