using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    private float _expOrbValue = 1;
    // Start is called before the first frame update

    public void Drop(float expYield)
    {
        _expOrbValue = expYield;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerLevel>().GainExperience(_expOrbValue);
            Destroy(this.gameObject);
        }
    }
}
