using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prindle_PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeeed;
    [SerializeField] private float damage =25;
    public Prindle_PlayerLevel level;
    public GameObject player;
    float timeUntilMelee =0f;
    public float ultiTimer =0f;
    public float tacttTimer =0f;
    
    AudioSource aud;
    public AudioClip hit, tact, ult;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        level = player.GetComponent<Prindle_PlayerLevel>();
    }
    private void Update()
    {
        
        if (timeUntilMelee <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                anim.SetTrigger("Attack");
                timeUntilMelee = level.weaponSpeed;
                print(timeUntilMelee);
                aud.clip = hit;
                aud.Play();
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
        if (tacttTimer <= 0)
        {
            if(Input.GetMouseButtonDown(1) && level.canTact == true)
            {
                
                anim.SetTrigger("tact");
                tacttTimer = level.tactTimer;
                aud.clip = tact;
                aud.Play();
            }
        }
        else
        {
            tacttTimer =-Time.deltaTime;
        }
        if (ultiTimer <= 0)
        {
            if(Input.GetKeyDown("e") && level.canTact == true)
            {
                
                anim.SetTrigger("ult");
                ultiTimer = level.ultTimer;
                print("eeee");
                aud.clip = ult;
                aud.Play();
            }
        }
        else
        {
            ultiTimer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Prindle_Enemy>().TakeDamage(damage);
            level.xpNeeded -= 35;
            Debug.Log("Enemy Hit");
            aud.Play();
        }
    }
}
