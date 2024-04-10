using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PersonajeAtaque : MonoBehaviour
{
    [SerializeField] private GameObject AttackColl;

    public static Action EventoAtaque;

    float look;
    float attackCool = 2;
    float timer;
    void Update()
    {
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
            look = -1; 
        }

        if (Input.GetMouseButtonDown(0) && attackCool>=0.5f)
        {
            timer = 0;
            Vector2 posAtaque = new Vector2(gameObject.transform.position.x+look, gameObject.transform.position.y); 
            Instantiate(AttackColl, posAtaque, Quaternion.identity);
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + (look * 5), gameObject.transform.position.y);
            attackCool = 0;
            EventoAtaque?.Invoke();
            while (timer<0.6f) 
            {
                timer += Time.deltaTime;
            }
            if (timer>=0.6f)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - (look*5), gameObject.transform.position.y);
            }
        }
    }
}
