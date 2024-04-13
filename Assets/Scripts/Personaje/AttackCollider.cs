using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class AttackCollider : MonoBehaviour
{
    float t;
    [SerializeField] private float range;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float daño;

    private void Awake()
    {
        t = 0;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(gameObject.transform.position, range, mask);
        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.tag == "Enemigo")
            {
                enemy.gameObject.GetComponent<EnemigoVida>().RecibirDaño(daño);
            }
        }
    }
    private void Update()
    {
        t += Time.deltaTime;
        if (t > 0.5f)
        {
            GameObject.Destroy(gameObject);
        }
    }

}

