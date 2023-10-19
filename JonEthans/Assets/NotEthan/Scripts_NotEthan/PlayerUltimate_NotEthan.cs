using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerUltimate_NotEthan : MonoBehaviour
{
    private SpriteRenderer player;
    private Color col;
    float cooldown;
    public bool isInvisible = false;
    public int damageMultiplier;
    public XPManager_EthanH levelRef;
    void Start()
    {
        player = GetComponent<SpriteRenderer>();
        col = player.color;
        cooldown = 10;
        damageMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            invisible();
        }
        if (isInvisible == false)
        { 
        visible();
        }
        if (levelRef.level == 6)
        {
            cooldown = 5;
        }
    }



    void visible()
    {
        isInvisible = false; 
        col.a = 1;
        player.color = col;
        damageMultiplier = 1;
    }
    void invisible()
    {
        isInvisible = true;
        col.a = 0.2f;
        player.color = col;
        damageMultiplier = 8;
    }
}
