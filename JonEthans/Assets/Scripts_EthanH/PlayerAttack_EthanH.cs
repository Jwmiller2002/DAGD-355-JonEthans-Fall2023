using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SearchService;

public class PlayerAttack_EthanH : MonoBehaviour
{

    [SerializeField] private Animator anim;
    [SerializeField] private float attackSpeed;
    [SerializeField] private int damage;
    public ParticleSystem batFX;
    public AudioSource bat;
    public AudioSource swing;
    private float attackRate;
    private float ultimateCD;
    public int level = 0;
    public int xp;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            level++;
            Debug.Log(level);
        }

        if (attackRate <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                damage = 5;
                attackRate = 1;
                swing.Play();
            }
            else if (Input.GetMouseButtonDown(1) && level >= 4)
            {
                anim.SetTrigger("HAttack");
                damage = 7;
                attackRate = 1;
                swing.Play();
            }
            else if (Input.GetMouseButtonDown(2))
            {
                anim.SetTrigger("RAttack");
                GetComponent<KnifeManager>().knifeAmount--;
                if (GetComponent<KnifeManager>().knifeAmount <= 0) GetComponent<KnifeManager>().knifeAmount = 0;
                Debug.Log(GetComponent<KnifeManager>().knifeAmount);
                damage = 7;
                attackRate = 1;
            }
            else if (Input.GetKeyDown(KeyCode.E) && ultimateCD <= 0f)
            {
                if(level >= 9)
                {
                    anim.SetTrigger("Ultimate8");
                    attackRate = 11;
                    ultimateCD = 20f;
                }
                else if(level >= 6)
                {
                    anim.SetTrigger("Ultimate");
                    attackRate = 11;
                    ultimateCD = 20f;
                }
                else if(level >= 3)
                {
                    anim.SetTrigger("Ultimate");
                    attackRate = 11;
                    ultimateCD = 30f;
                }
            }
        }
        else
        {
            attackRate -= Time.deltaTime;
        }

        //ultimateCD -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if(level >= 7)
            {
                other.GetComponent<Golem_EthanH>().knockedBackCD += 2f;
                other.GetComponent<Golem_EthanH>().knockback(1f);
                other.GetComponent<Golem_EthanH>().takeDamage(damage);
                other.GetComponent<Golem_EthanH>().anim.SetTrigger("Hit");
            }
            else if(level >= 2)
            {
                other.GetComponent<Golem_EthanH>().knockedBackCD += 2f;
                other.GetComponent<Golem_EthanH>().knockback(0.5f);
                other.GetComponent<Golem_EthanH>().takeDamage(damage);
                other.GetComponent<Golem_EthanH>().anim.SetTrigger("Hit");
            }
            else
            {
                other.GetComponent<Golem_EthanH>().takeDamage(damage);
                other.GetComponent<Golem_EthanH>().anim.SetTrigger("Hit");
            }
            bat.Play();
        }
        if (other.tag == "Bullet")
        {
            if(level >= 10)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
                other.GetComponent<BulletMovement_EthanH>().Deflect(direction);
                other.GetComponent<BulletMovement_EthanH>().enemyCollision = true;
            }
            else if(level >= 8)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
                other.GetComponent<BulletMovement_EthanH>().Deflect(direction);
                other.GetComponent<BulletMovement_EthanH>().enemyCollision = true;
            }
            else if(level >= 1)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
                other.GetComponent<BulletMovement_EthanH>().Deflect(direction);
                other.GetComponent<BulletMovement_EthanH>().enemyCollision = true;
                batFX.Play();
            }
            else
            {
                Destroy(other.gameObject);
                batFX.Play();
            }
            bat.Play();
        }
        if(other.tag == "Rocket")
        {
            if(level >= 5)
            {
                //Deflect()
            }
            else 
            { 
                Destroy(other.gameObject); 
            }
            bat.Play();
        }
    }
}
