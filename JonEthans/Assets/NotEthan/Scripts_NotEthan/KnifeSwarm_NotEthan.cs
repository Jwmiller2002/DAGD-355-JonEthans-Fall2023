using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public PlayerTeleport_NotEthan teleportRef;
    XPManager_EthanH levelRef;
    // Start is called before the first frame update
    void Start()
    {
        levelRef = GetComponent<XPManager_EthanH>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (teleportRef.isTeleport == true && levelRef.level <= 2)
        {
            if (other.tag == "notEthan_Enemy")
            {
                other.GetComponent<EnemyController_NotEthan>().bleedStacks++;
            }
            else if (other.tag == "EthanH_Enemy")
            {
                other.GetComponent<Golem_EthanH>().bleedStacks++;
            }
                teleportRef.isTeleport = false;
        }
    }
}
