using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;
    [SerializeField] private float damage = 5f;                     //enemy damage
    [SerializeField] private float health, maxHealth = 3f;          //enemy health
    [SerializeField] private float expYield = 2;               //how many points the player gets for killing the enemy
    [SerializeField] private float moveSpeed = 1f;                  //enemy movement speed
   
    
    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;

    [SerializeField] private GameObject _expPrefab;
    

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
            GameObject exp = Instantiate(_expPrefab, transform.position, Quaternion.identity);
            exp.GetComponent<Experience>().Drop(expYield);
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
