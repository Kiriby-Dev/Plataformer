using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PersonajeAtaque : MonoBehaviour
{
    [SerializeField] private GameObject AttackColl;

    public static Action EventoAtaque;
    private Rigidbody2D _rigidbody;

    private PersonajeMovimiento _personajeMovimiento;

    private float look = 1f;
    private float attackCool = 2;
    private float timer;
    private bool ataque=false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _personajeMovimiento = GetComponent<PersonajeMovimiento>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (attackCool < 0.5f)
        {
            attackCool += Time.deltaTime;
        }
        
        if (Input.GetKeyUp(KeyCode.D))
        {
            look = 1;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            look = -1f; 
        }

        if (Input.GetMouseButtonDown(0) && attackCool>=0.5f && _personajeMovimiento.tocandoSuelo)
        {
            timer = 0;
            _rigidbody.isKinematic = true;
            _personajeMovimiento._input = 0;
            _rigidbody.velocity = Vector3.zero;
            gameObject.GetComponent<PersonajeMovimiento>().enabled = false;
            Vector2 posAtaque = new Vector2(gameObject.transform.position.x+(look*1.25f), gameObject.transform.position.y); 
            Instantiate(AttackColl, posAtaque, Quaternion.identity);
            attackCool = 0;
            EventoAtaque?.Invoke();
            ataque = true;
        }
        if (ataque && timer > 0.35f)
        {
            _rigidbody.isKinematic = false;
            gameObject.GetComponent<PersonajeMovimiento>().enabled = true;
            ataque = false;
        }
    }
}
