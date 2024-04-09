using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float fuerzaSalto;
    public static Action EventoSalto;
    public static Action<bool> EventoCaer;
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

        if (Input.GetKey(KeyCode.Space) && tocandoSuelo)
        {
            tocandoSuelo = false;
            _rigidbody2D.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
            PersonajeSalto();
        }
        bool cayendo = _rigidbody2D.velocity.y < 0f;
        EventoCaer?.Invoke(cayendo);
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

    private void PersonajeSalto()
    {
        EventoSalto?.Invoke();
    }
}
