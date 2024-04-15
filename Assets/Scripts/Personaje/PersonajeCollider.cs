using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class PersonajeCollider : MonoBehaviour
{
    public PersonajeVida personajevida;
    public PersonajeMovimiento personajevidaMovimiento;
    public PersonajeAtaque personajeAtaque;
    void Start()
    {

    }


    void Update()
    {
        if (!personajeAtaque.ataque)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 0.3f);
            }
            if (personajevidaMovimiento.DePie)
            {
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.1f, 1.95f);
            }
            else if (personajevidaMovimiento.Agachado)
            {
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.1f, 1.35f);
            }
        }
    }
}
