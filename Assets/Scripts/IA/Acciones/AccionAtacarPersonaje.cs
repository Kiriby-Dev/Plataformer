using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IA/Acciones/AtacarPersonaje")]
public class AccionAtacarPersonaje : IAAccion
{
    public static Action EventoAtaque;
    public override void Ejecutar(IAController controller)
    {
        Atacar(controller);
    }

    private void Atacar(IAController controller) 
    {
        if (controller.PersonajeReferencia == null || controller.EsTiempoDeAtacar() == false) 
        {
            return;
        }

        if (controller.PersonajeEnRangoDeAtaque(controller.RangoDeAtaque)) 
        {
            EventoAtaque?.Invoke();
            controller.AtaqueMelee(controller.Daño);
            controller.ActualizarTiempoEntreAtaques();
        }
    }
}
