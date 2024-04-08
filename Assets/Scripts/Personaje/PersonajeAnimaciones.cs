using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeAnimaciones : MonoBehaviour
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerCorrer;

    private Animator animator;
    private PersonajeMovimiento personajeMovimiento;

    private readonly int derrotado = Animator.StringToHash("Derrotado");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        personajeMovimiento = GetComponent<PersonajeMovimiento>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        ActualizarLayers();

        /*if (personajeMovimiento.EnMovimiento == false)
        {
            return;
        }
        animator.SetFloat("X", personajeMovimiento.DireccionMovimiento.x);
        animator.SetFloat("Y", personajeMovimiento.DireccionMovimiento.y);*/
    }

    private void ActivarLayer(string nombreLayer) 
    {
        for (int i = 0; i < animator.layerCount; i++) 
        {
            animator.SetLayerWeight(i, 0);
        }

        animator.SetLayerWeight(animator.GetLayerIndex(nombreLayer), 1);
    }

    private void ActualizarLayers() 
    {
        if (personajeMovimiento.EnMovimiento)
        {
            ActivarLayer(layerCorrer);
        }
        else 
        {
            ActivarLayer(layerIdle);
        }
    }

    private void PersonajeDerrotadoRespuesta() 
    {
        if (animator.GetLayerWeight(animator.GetLayerIndex(layerCorrer)) == 1 || animator.GetLayerWeight(animator.GetLayerIndex(layerIdle)) == 1)
        {
            animator.SetBool(derrotado, true);
        }
    }

    private void OnEnable()
    {
        PersonajeVida.EventoPersonajeDerrotado += PersonajeDerrotadoRespuesta;
    }

    private void OnDisable()
    {
        PersonajeVida.EventoPersonajeDerrotado -= PersonajeDerrotadoRespuesta;
    }
}
