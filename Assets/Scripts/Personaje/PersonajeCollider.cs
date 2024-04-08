using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeCollider : MonoBehaviour
{
    public PersonajeVida personajevida;
    void Start()
    {
        
    }

    void Update()
    {
        if (personajevida.Salud<=0)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(2.2f, 0.65f);
        }
    }
}
