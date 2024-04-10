using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    float t;
    [SerializeField] private float range = 0.5f;
    [SerializeField] private LayerMask mask;
    private void Awake()
    {
        t = 0;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(gameObject.transform.position, range, mask);
        foreach  (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.tag == "Enemigo") 
            {
                GameObject.Destroy(enemy.gameObject);
            }
        }
    }
    private void Update()
    {
        t += Time.deltaTime;
        if (t>1)
        {
            GameObject.Destroy(gameObject);
        }
    }

}

