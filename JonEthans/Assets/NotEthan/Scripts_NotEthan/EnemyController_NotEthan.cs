using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController_NotEthan : MonoBehaviour
{
    public ParticleSystem bleedEffect;
    public float bleedStacks = 0;
    public float enemyHealth = 5;
    float bleedTime = 0;
    public GameObject Dagger_Pickup;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bleedStacks > 0)
        {
            Bleed();
            bleedParticle();
        }
        if (enemyHealth <= 0f)
        {            
            Destroy(gameObject);
            float itemChance = Random.Range(0, 20);
            if (itemChance <= 1)
            {
                Instantiate(Dagger_Pickup, transform.position, Quaternion.identity);
            }
        }

    }

    public void Bleed()
    {
        float bleedDamage = 1;        
        bleedTime -= Time.deltaTime;
        if (bleedTime <= 0)
        {
            enemyHealth -= bleedDamage * bleedStacks;
            bleedTime = 10;
            bleedParticle();
        }
        
        
    }

    public void TakeDamage(float damage) 
    {
        enemyHealth -= damage;
    }

    void bleedParticle()
    {
        bleedEffect.Play();
    }

}
