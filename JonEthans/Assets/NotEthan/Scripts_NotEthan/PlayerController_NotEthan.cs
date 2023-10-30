using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_NotEthan : MonoBehaviour
{
    private Rigidbody2D rb;
    public HealthManager_EthanH healthRef;
    public bool isDead = false;
    public GameObject endScreen;


    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        endScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (healthRef.healthAmount <= 0)
        {
            anim.SetTrigger("Die");
            isDead = true;
            endScreen.SetActive(true);

        }
    }
}
