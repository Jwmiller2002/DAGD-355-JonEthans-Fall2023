using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EP_PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float playerhurtdamage =5f;
    public float health = 20f;
    
    private Vector2 mousePos;
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical"); 
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y -transform.position.y, mousePos.x - transform.position.x) *Mathf.Rad2Deg -90f;

        transform.localRotation = Quaternion.Euler(0, 0, angle);
        transform.position += new Vector3(h,v,0f) *speed *Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            
            Destroy(other.gameObject);
            Debug.Log("Shot");
            health -= playerhurtdamage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
