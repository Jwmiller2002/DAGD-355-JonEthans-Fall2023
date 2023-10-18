using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel_NotEthan : MonoBehaviour
{
    public int level = 0;
    public float exp = 0;
    float neededEXP = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (exp >= neededEXP)
        {
            level++;
            neededEXP = neededEXP * 2;
            exp = 0;
        }
    }

    public void addXP(int xp)
    {
        exp += xp;
    }
}
