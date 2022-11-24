using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent));
           
        {
            enemyComponent.TakeDamage(1);
        }
    }
}