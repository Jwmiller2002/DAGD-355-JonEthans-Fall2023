using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel_NotEthan : MonoBehaviour
{
    public int level = 0;
    public float exp = 0;
    float neededEXP = 10;
    public float knifeNumber = 1;
    public XPManager_EthanH xpManager;
    
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
            xpManager.ResetBar();
            neededEXP = neededEXP * 2;
            exp = 0;
            if (level == 4)
            { 
                knifeNumber = 2;
            }
        }
    }

    public void addXP(int xp)
    {
        exp += xp;
        xpManager.GainXP(xp);

    }
}
