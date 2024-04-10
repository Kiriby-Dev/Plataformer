using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    [Header("Estados")]
    [SerializeField] private IAEstado estadoInicial;
    [SerializeField] private IAEstado estadoDefault;

    [Header("Configuracion")]
    [SerializeField] private float rangoDeteccion;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private LayerMask personajeLayerMask;

    public Rigidbody2D rigidbody2D_;
    public Transform PersonajeReferencia { get; set; }
    public IAEstado EstadoActual { get; set; }
    public float RangoDeteccion => rangoDeteccion;
    public float VelocidadMovimiento { get; set; }
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
}
