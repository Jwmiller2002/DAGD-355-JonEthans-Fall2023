using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public PlayerTeleport_NotEthan teleportRef;
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
        if (teleportRef.isTeleport == true)
        {
            if (other.tag == "enemy")
            {
                other.GetComponent<EnemyController_NotEthan>().bleedStacks++;
            }
            teleportRef.isTeleport = false;
        }
    }
}
