using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPManager_EthanH : MonoBehaviour
{

    public Image xpBar;
    public float xpAmount;
    public float nextLevelAmount;

    // Start is called before the first frame update
    void Start()
    {
        nextLevelAmount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GainXP(float xpGain)
    {
        xpAmount += xpGain;
        xpAmount = Mathf.Clamp(xpAmount, 0, nextLevelAmount);

        xpBar.fillAmount = xpAmount / 10f;
    }

    public void ResetBar()
    {
        xpAmount = 0;
        nextLevelAmount = nextLevelAmount * 2;
    }

}
