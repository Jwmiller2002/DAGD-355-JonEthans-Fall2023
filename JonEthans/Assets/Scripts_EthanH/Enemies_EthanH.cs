using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_EthanH : MonoBehaviour
{

    public int health = 10;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        Debug.Log("ouch");
    }
}
