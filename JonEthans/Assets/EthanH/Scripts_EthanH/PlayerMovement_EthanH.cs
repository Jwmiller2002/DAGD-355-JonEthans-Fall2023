using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement_EthanH : MonoBehaviour
{

    [SerializeField] public Animator anim;
    public AudioSource bread;
    private Rigidbody2D rb;
    public int health = 100;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            Vector3 pos = transform.position;

            if (Input.GetKey("w"))
            {
                pos.y += speed * Time.deltaTime;
            }
            if (Input.GetKey("s"))
            {
                pos.y -= speed * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                pos.x += speed * Time.deltaTime;
                //anim walk right
                anim.SetFloat("Right", 1f);
            }
            if (Input.GetKeyUp("d"))
            {
                anim.SetFloat("Right", 0f);
                anim.SetTrigger("StopRight");
            }
            if (Input.GetKey("a"))
            {
                pos.x -= speed * Time.deltaTime;
                //anim walk left
                anim.SetFloat("Left", 1f);
            }
            if (Input.GetKeyUp("a"))
            {
                anim.SetFloat("Left", 0f);
                anim.SetTrigger("StopLeft");
            }


            transform.position = pos;
        }
        else
        {
            anim.SetTrigger("Dead");
        }

        if (Input.GetKeyDown("space"))
        {
            GetComponent<KnifeManager>().knifeAmount++;
            if (GetComponent<KnifeManager>().knifeAmount > 3) GetComponent<KnifeManager>().knifeAmount = 3;
            Debug.Log(GetComponent<KnifeManager>().knifeAmount);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Baguette")
        {
            GetComponent<HealthManager_EthanH>().Heal(25);
            if (health > 100) health = 100;
            bread.Play();
            Destroy(other.gameObject);
            Debug.Log(health);
        }
        if(other.tag == "Ethan2_Bullet")
        {
            Destroy(other.gameObject);
            GetComponent<HealthManager_EthanH>().TakeDamage(5);
            anim.SetTrigger("Hit");
        }
        if (other.tag == "Rocket")
        {
            GetComponent<HealthManager_EthanH>().TakeDamage(10);
            anim.SetTrigger("Hit");
        }
        if (other.tag == "Knife")
        {
            GetComponent<KnifeManager>().knifeAmount++;
            if (GetComponent<KnifeManager>().knifeAmount > 3) GetComponent<KnifeManager>().knifeAmount = 3;
            Destroy(other.gameObject);
        }
    }
}
