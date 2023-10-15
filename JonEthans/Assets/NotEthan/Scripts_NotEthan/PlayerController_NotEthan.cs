using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_NotEthan : MonoBehaviour
{
    private Rigidbody2D rb;
    public float playerHealth = 6f;
    public bool isDead = false;

    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            anim.SetTrigger("Die");
            isDead = true;
        }
    }
}
