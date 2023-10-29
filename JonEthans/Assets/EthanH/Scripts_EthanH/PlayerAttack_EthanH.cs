using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
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
        if (attackRate <= 0f && GetComponent<HealthManager_EthanH>().healthAmount > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                damage = 5;
                attackRate = 1;
                swing.Play();
            }
            else if (Input.GetMouseButtonDown(1) && GetComponent<XPManager_EthanH>().level >= 4)
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
                if(GetComponent<XPManager_EthanH>().level >= 9)
                {
                    anim.SetTrigger("Ultimate8");
                    attackRate = 11;
                    ultimateCD = 20f;
                }
                else if(GetComponent<XPManager_EthanH>().level >= 6)
                {
                    anim.SetTrigger("Ultimate");
                    attackRate = 11;
                    ultimateCD = 20f;
                }
                else if(GetComponent<XPManager_EthanH>().level >= 3)
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
        if (other.tag == "EthanH_Enemy")
        {
            if(GetComponent<XPManager_EthanH>().level >= 7)
            {
                other.GetComponent<Golem_EthanH>().knockedBackCD += 2f;
                other.GetComponent<Golem_EthanH>().knockback(1f);
                other.GetComponent<Golem_EthanH>().takeDamage(damage);
                other.GetComponent<Golem_EthanH>().anim.SetTrigger("Hit");
            }
            else if(GetComponent<XPManager_EthanH>().level >= 2)
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
        if(other.tag == "Ethan2_Enemy")
        {
            if (GetComponent<XPManager_EthanH>().level >= 7)
            {
                other.GetComponent<Prindle_Enemy>().knockedBackCD += 2f;
                other.GetComponent<Prindle_Enemy>().knockback(1f);
                other.GetComponent<Prindle_Enemy>().TakeDamage(damage);
            }
            else if (GetComponent<XPManager_EthanH>().level >= 2)
            {
                other.GetComponent<Prindle_Enemy>().knockedBackCD += 2f;
                other.GetComponent<Prindle_Enemy>().knockback(0.5f);
                other.GetComponent<Prindle_Enemy>().TakeDamage(damage);
            }
            else
            {
                other.GetComponent<Prindle_Enemy>().TakeDamage(damage);
            }
            bat.Play();
        }
        if (other.tag == "notEthan_Enemy")
        {
            other.GetComponent<EnemyController_NotEthan>().TakeDamage(damage);
            bat.Play();
        }
        if (other.tag == "EthanH_Bullet")
        {
            if(GetComponent<XPManager_EthanH>().level >= 10)
            {
                Vector3 pos = transform.position;
                float dist = float.PositiveInfinity;
                ChaseableEntity_EthanH targ = null;
                foreach (var obj in ChaseableEntity_EthanH.Entities)
                {
                    var d = (pos - obj.transform.position).sqrMagnitude;
                    if (d < dist)
                    {
                        targ = obj;
                        dist = d;
                    }
                }

                Vector3 direction = targ.transform.position - transform.position;
                other.GetComponent<BulletMovement_EthanH>().Split();
                other.GetComponent<BulletMovement_EthanH>().rb.velocity = new Vector2(direction.x, direction.y).normalized * other.GetComponent<BulletMovement_EthanH>().force;
                other.GetComponent<BulletMovement_EthanH>().enemyCollision = true;
            }
            else if(GetComponent<XPManager_EthanH>().level >= 8)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
                other.GetComponent<BulletMovement_EthanH>().Split();
                other.GetComponent<BulletMovement_EthanH>().Deflect(direction);
                other.GetComponent<BulletMovement_EthanH>().enemyCollision = true;
            }
            else if(GetComponent<XPManager_EthanH>().level >= 1)
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
        if(other.tag == "Ethan2_Bullet")
        {
            if (GetComponent<XPManager_EthanH>().level >= 10)
            {
                Vector3 pos = transform.position;
                float dist = float.PositiveInfinity;
                ChaseableEntity_EthanH targ = null;
                foreach (var obj in ChaseableEntity_EthanH.Entities)
                {
                    var d = (pos - obj.transform.position).sqrMagnitude;
                    if (d < dist)
                    {
                        targ = obj;
                        dist = d;
                    }
                }

                Vector3 direction = targ.transform.position - transform.position;
                other.GetComponent<Bullet>().Split();
                other.GetComponent<Bullet>().rb.velocity = new Vector2(direction.x, direction.y).normalized * other.GetComponent<Bullet>().bulletSpeed;
            }
            else if (GetComponent<XPManager_EthanH>().level >= 8)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
                other.GetComponent<Bullet>().Split();
                other.GetComponent<Bullet>().Deflect(direction);
            }
            else if (GetComponent<XPManager_EthanH>().level >= 1)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
                other.GetComponent<Bullet>().Deflect(direction);
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
            if(GetComponent<XPManager_EthanH>().level >= 5)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
                other.GetComponent<Bullet>().Deflect(direction);
            }
            else 
            { 
                Destroy(other.gameObject); 
            }
            bat.Play();
        }
    }
}
