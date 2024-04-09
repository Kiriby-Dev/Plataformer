using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private float velocidad;
    [SerializeField] private float fuerzaSalto;
    
    public static Action EventoSalto;
    public static Action<bool> EventoCaer;
    public static Action<bool> EventoAgachado;
    
    public bool EnMovimiento => direccionMovimiento.magnitude > 0f;
    public Vector2 DireccionMovimiento => direccionMovimiento;
    public bool Agachado => agachado;
    public bool DePie => dePie;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Vector2 direccionMovimiento;
    private float _input;
    private bool tocandoSuelo;
    private float jumpCooldown;
    private float jumpCoolMax;
    private bool agachado;
    private bool dePie = true;

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
            EventoAgachado?.Invoke(agachado);
        }
        else 
        {
            agachado = false;
            dePie = true;
            EventoAgachado?.Invoke(agachado);
        }

        if (Input.GetKey(KeyCode.Space) && tocandoSuelo && jumpCooldown == 0)
        {
            tocandoSuelo = false;
            jumpCooldown = jumpCoolMax;
            _rigidbody2D.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
            PersonajeSalto();
        }
        bool cayendo = _rigidbody2D.velocity.y < 0f;
        EventoCaer?.Invoke(cayendo);
        if (jumpCooldown > 0)
        {
            jumpCooldown -= Time.deltaTime;
        }
        else
        {
            jumpCooldown = 0;
        }

        if (agachado)
        {
            _rigidbody2D.mass = 3f;
            jumpCoolMax = 0.5f;
        }
        else
        {
            _rigidbody2D.mass = 2.2f;
            jumpCoolMax = 0.6f;
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

    private void PersonajeSalto()
    {
        EventoSalto?.Invoke();
    }
}
