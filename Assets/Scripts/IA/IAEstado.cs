using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="IA/Estado")]
public class IAEstado : ScriptableObject
{
    public IAAccion[] Acciones;
    public IATransicion[] Transiciones;

    private void EjecutarAccion(IAController controller) 
    {
        if (Acciones == null || Acciones.Length <= 0) 
        {
            return;
        }

        for (int i = 0; i < Acciones.Length; i++) 
        {
            Acciones[i].Ejecutar(controller);
        }
    }

    private void RalizarTransiciones(IAController controller) 
    {
        if (Transiciones == null || Transiciones.Length <= 0)
        {
            return;
        }
    }
}
