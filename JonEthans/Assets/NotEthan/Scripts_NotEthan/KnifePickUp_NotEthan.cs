using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePickUp_NotEthan : MonoBehaviour
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
        if (other.tag == "Player")
        {
            if (other.GetComponent<PlayerThrow_NotEthan>().knifeAmount < 3)
            {
                other.GetComponent<PlayerThrow_NotEthan>().knifeAmount++;
                Destroy(gameObject);
            }
        }
    }
}
