using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EnemigoAnimaciones : MonoBehaviour
{
    [Header("Sonido")]
    [SerializeField] private AudioClip enemyHit;
    [SerializeField] private AudioClip enemyDeath;
    [SerializeField] private AudioClip enemyAttack;

    private IAController controller;
    private Animator animator;
    private Rigidbody2D enemigo;
    private SpriteRenderer spriteRenderer;
    private EnemigoVida enemigoVida;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemigo = GetComponent<Rigidbody2D>();
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
        ControladorSonido.Instance.EjecutarSonido(enemyAttack);
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
        AccionAtacarPersonaje.EventoAtaque += EnemigoAtaqueRespuesta;
        if (enemigoVida != null) 
        {
            enemigoVida.EventoEnemigoDerrotado += EnemigoDerrotadoRespuesta;
        }

        if (enemigoVida != null)
        {
            enemigoVida.EventoEnemigoDañado += EnemigoDañadoRespuesta;
        }
    }

    private void OnDisable()
    {
        AccionAtacarPersonaje.EventoAtaque -= EnemigoAtaqueRespuesta;
        if (enemigoVida != null)
        {
            enemigoVida.EventoEnemigoDerrotado -= EnemigoDerrotadoRespuesta;
        }

        if (enemigoVida != null)
        {
            enemigoVida.EventoEnemigoDañado -= EnemigoDañadoRespuesta;
        }
    }
}
