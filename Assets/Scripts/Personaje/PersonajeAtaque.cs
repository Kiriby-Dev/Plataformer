using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PersonajeAtaque : MonoBehaviour
{
    [SerializeField] private GameObject AttackColl;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 posAtaque = new Vector2(gameObject.transform.position.x+1f, gameObject.transform.position.y); 
            Instantiate(AttackColl, posAtaque, Quaternion.identity);
        }
    }
}
