using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUltimate_NotEthan : MonoBehaviour
{
    private SpriteRenderer player;
    private Color col;
    float cooldown = 10;
    public bool isInvisible = false;
    public float damageMultiplier;
    void Start()
    {
        player = GetComponent<SpriteRenderer>();
        col = player.color;
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
