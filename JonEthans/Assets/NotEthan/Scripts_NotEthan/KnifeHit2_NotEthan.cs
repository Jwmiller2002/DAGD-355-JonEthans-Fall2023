using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHit2_NotEthan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Hit");
        if (other.tag == "Enemy")
        {
            
            Debug.Log("ENEMY HIT");
        }
    }
}
