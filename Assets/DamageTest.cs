using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        collision.gameObject.GetComponent<PlayerController>().TakeDamage(10);   
    }
}
