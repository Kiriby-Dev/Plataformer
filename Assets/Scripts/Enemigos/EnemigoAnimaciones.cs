using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EnemigoAnimaciones : MonoBehaviour
{
    [Header("Sonido")]
    [SerializeField] private AudioClip enemyHit;
    [SerializeField] private AudioClip enemyDeath;

    private IAController controller;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private EnemigoVida enemigoVida;
    private AccionAtacarPersonaje enemigoAtaque;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<IAController>();
        enemigoVida = controller.GetComponent<EnemigoVida>();
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

    private void EnemigoDañadoRespuesta()
    {
        animator.SetTrigger("Dañado");
        ControladorSonido.Instance.EjecutarSonido(enemyHit);
    }

    private void EnemigoDerrotadoRespuesta()
    {
        animator.SetBool("Derrotado", true);
        ControladorSonido.Instance.EjecutarSonido(enemyDeath);
    }

    private void OnEnable()
    {
        controller.EventoAtaque += EnemigoAtaqueRespuesta;

        if (enemigoVida != null)
        {
            enemigoVida.EventoEnemigoDerrotado += EnemigoDerrotadoRespuesta;
            enemigoVida.EventoEnemigoDañado += EnemigoDañadoRespuesta;
        }
    }

    private void OnDisable()
    {
        controller.EventoAtaque -= EnemigoAtaqueRespuesta;

        if (enemigoVida != null)
        {
            enemigoVida.EventoEnemigoDerrotado -= EnemigoDerrotadoRespuesta;
            enemigoVida.EventoEnemigoDañado -= EnemigoDañadoRespuesta;
        }
    }
}
