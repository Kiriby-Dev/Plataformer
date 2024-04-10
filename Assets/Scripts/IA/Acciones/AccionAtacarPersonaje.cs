using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IA/Acciones/AtacarPersonaje")]
public class AccionAtacarPersonaje : IAAccion
{
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
            controller.AtaqueMelee(controller.Daño);
            controller.ActualizarTiempoEntreAtaques();
        }
    }
}
