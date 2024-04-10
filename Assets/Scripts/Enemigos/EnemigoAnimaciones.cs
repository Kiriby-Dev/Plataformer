using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EnemigoAnimaciones : MonoBehaviour
{
    private IAController controller;
    private Animator animator;
    private Rigidbody2D enemigo;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemigo = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<IAController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.PersonajeReferencia != null)
        {
            Vector3 dirHaciaPersonaje = (controller.PersonajeReferencia.position - controller.transform.position).normalized;

            if (dirHaciaPersonaje.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (dirHaciaPersonaje.x < 0)
            {
                spriteRenderer.flipX = true;
            }

            animator.SetBool("EnMovimiento", true);
        }
        else 
        {
            animator.SetBool("EnMovimiento", false);
        }
    }

    private void EnemigoAtaqueRespuesta()
    {
        animator.SetTrigger("Ataque");
    }

    private void OnEnable()
    {
        AccionAtacarPersonaje.EventoAtaque += EnemigoAtaqueRespuesta;
    }

    private void OnDisable()
    {
        AccionAtacarPersonaje.EventoAtaque -= EnemigoAtaqueRespuesta;
    }
}
