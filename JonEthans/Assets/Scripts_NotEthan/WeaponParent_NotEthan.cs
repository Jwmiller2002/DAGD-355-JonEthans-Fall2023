using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent_NotEthan : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }

    void Update()
    {
        transform.right = (PointerPosition - (Vector2)transform.position).normalized;
    }
}
