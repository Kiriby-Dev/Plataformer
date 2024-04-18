using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IA/Acciones/SeguirPersonaje")]
public class AccionSeguirPersonaje : IAAccion
{
    public override void Ejecutar(IAController controller)
    {
        if (controller.gameObject.tag == "Enemigo")
        {
            if (controller.gameObject.GetComponent<EnemigoVida>().Salud > 0 && !controller.gameObject.GetComponent<EnemigoVida>().EstaInmovilizado)
            {
                SeguirPersonaje(controller);
            }
        }
        else 
        {
            SeguirPersonaje(controller);
        }
        
    }

    private void SeguirPersonaje(IAController controller) 
    {
        if (controller.PersonajeReferencia == null) 
        {
            return;
        }

        /*Vector2 dirHaciaPersonaje = controller.PersonajeReferencia.position - controller.transform.position;
        Vector2 direccion = dirHaciaPersonaje.normalized;
        float distancia = dirHaciaPersonaje.magnitude;
        if (distancia >= 1.5f) 
        {
            controller.transform.Translate(direccion * controller.VelocidadMovimiento * Time.deltaTime);
        }*/

        if (controller.gameObject.tag == "Fairy")
        {
            Vector2 dirHaciaPersonaje = controller.PersonajeReferencia.position - controller.transform.position;
            Vector2 direccion = new Vector2(dirHaciaPersonaje.x, dirHaciaPersonaje.y + 1).normalized; // Solo afecta al eje x
            float distancia = dirHaciaPersonaje.magnitude;

            if (distancia >= 1.5f)
            {
                controller.transform.Translate(direccion * controller.VelocidadMovimiento * Time.deltaTime);
            }
        }

        if (controller.gameObject.tag == "Enemigo")
        {
            Vector2 dirHaciaPersonaje = controller.PersonajeReferencia.position - controller.transform.position;
            Vector2 direccion = new Vector2(dirHaciaPersonaje.x, 0f).normalized; // Solo afecta al eje x
            float distancia = dirHaciaPersonaje.magnitude;
        
            if (distancia >= 1.5f)
            {
                // Conservar la posición en y actual
                float posY = controller.transform.position.y;

                // Mover solo en el eje x
                controller.transform.Translate(new Vector3(direccion.x, 0f, 0f) * controller.VelocidadMovimiento * Time.deltaTime);

                // Restaurar la posición en y original
                Vector3 newPos = controller.transform.position;
                newPos.y = posY;
                controller.transform.position = newPos;
            }
        }
    }
}
