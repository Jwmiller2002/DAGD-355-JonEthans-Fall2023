using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController_NotEthan : MonoBehaviour
{

    public float enemyHealth = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage) 
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0f)
        { 
        Destroy(gameObject);
        }
    }
}
