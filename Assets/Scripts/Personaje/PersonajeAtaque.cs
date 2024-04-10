using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PersonajeAtaque : MonoBehaviour
{
    [SerializeField] private GameObject AttackColl;
    float look;
    float attackCool = 2;
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
            Vector2 posAtaque = new Vector2(gameObject.transform.position.x+look, gameObject.transform.position.y); 
            Instantiate(AttackColl, posAtaque, Quaternion.identity);
            attackCool = 0;
        }
    }
}
