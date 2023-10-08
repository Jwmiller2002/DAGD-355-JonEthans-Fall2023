using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport_NotEthan : MonoBehaviour
{
    private Rigidbody2D rb;
    public float teleportCooldown;
    float timeUntilTeleport;

    Vector3 mousePos;
    Vector2 pos = new Vector2(0f, 0f);

    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        pos = mousePos;

        if (timeUntilTeleport <= 0f)
        {
            if (Input.GetMouseButtonDown(1))
            {
                teleport();
                anim.SetTrigger("Teleport");
                timeUntilTeleport = teleportCooldown;
            }
        }
        else
        {
            timeUntilTeleport -= Time.deltaTime;
        }
    }

    void teleport()
    {
        rb.MovePosition(pos);
    }
}
