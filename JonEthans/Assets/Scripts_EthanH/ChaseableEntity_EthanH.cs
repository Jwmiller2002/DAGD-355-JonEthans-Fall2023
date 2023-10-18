using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class ChaseableEntity_EthanH : MonoBehaviour
{
    // Start is called before the first frame update
    public static readonly HashSet<ChaseableEntity_EthanH> Entities = new HashSet<ChaseableEntity_EthanH>();

    void Awake()
    {
        Entities.Add(this);
    }

    void OnDestroy()
    {
        Entities.Remove(this);
    }

}
