using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

<<<<<<< HEAD
=======
/* Code til enemy AI https:// www.youtube.com/watch?v=ZExSz7x69j8&t=1s */



>>>>>>> f681849a2f507298f26823eb7da8e21bfac4600b
public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;
    [SerializeField] private float health, maxHealth = 3f;

    [SerializeField] private float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        health = maxHealth;
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log($"DamageAmount: {damageAmount}");
        health -= damageAmount;
        Debug.Log($"Health is now {health}");

        if (health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
        
    }
  
}
