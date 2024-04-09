using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    [SerializeField] private float velocidad;
    public float fuerzaSalto;
    public static Action EventoSalto;
    public bool EnMovimiento => direccionMovimiento.magnitude > 0f;
    public bool tocandoSuelo;
    public bool agachado;
    public bool dePie = true;
    public Vector2 DireccionMovimiento => direccionMovimiento;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Vector2 direccionMovimiento;
    private float _input;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _input = Input.GetAxisRaw("Horizontal");

        if (_input > 0f)
        {
            direccionMovimiento.x = 1f;
            spriteRenderer.flipX = false;
        }
        else if (_input < 0f)
        {
            direccionMovimiento.x = -1f;
            spriteRenderer.flipX = true;
        }
        else
        {
            direccionMovimiento.x = 0f;
        }

        if (Input.GetKey(KeyCode.Space) && tocandoSuelo)
        {
            Saltar();
            PersonajeSalto();
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            agachado = true;
            dePie = false;
        }
        else 
        {
            agachado = false;
            dePie = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            tocandoSuelo = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            tocandoSuelo = false;
        }
    }

    private void FixedUpdate()
        {
        _rigidbody2D.velocity = new Vector2(direccionMovimiento.x * velocidad, _rigidbody2D.velocity.y);
        }

    void Saltar()
    {
        float yInicial = gameObject.transform.position.y;
        float t = 0;
        t = Time.deltaTime;
        Debug.Log(t);
        while (!tocandoSuelo)
        {
            float yFinal = yInicial + (t * fuerzaSalto) + (t * t * 9.81f);
            gameObject.transform.position = new Vector2(transform.position.x, yFinal);
        }
    }
    private void PersonajeSalto()
    {
        EventoSalto?.Invoke();
    }
}
