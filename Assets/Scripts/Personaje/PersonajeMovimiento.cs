using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float fuerzaSalto;

    public bool EnMovimiento => direccionMovimiento.magnitude > 0f;
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

        if (_input > 0.1f)
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

        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

        private void FixedUpdate()
        {
        _rigidbody2D.velocity = new Vector2(direccionMovimiento.x * velocidad, _rigidbody2D.velocity.y);
        }
}
