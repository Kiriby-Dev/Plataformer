using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeCollider : MonoBehaviour
{
    public PersonajeVida personajevida;
    public PersonajeMovimiento personajevidaMovimiento;
    void Start()
    {
        
    }

    void Update()
    {
        if (personajevida.Salud>0)
        {
            if (personajevidaMovimiento.dePie)
            {
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.1f, 2f);
            }
            else if (personajevidaMovimiento.agachado)
            {
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.1f, 1.5f);
            }
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(2.2f, 0.65f);
        }
    }
}
