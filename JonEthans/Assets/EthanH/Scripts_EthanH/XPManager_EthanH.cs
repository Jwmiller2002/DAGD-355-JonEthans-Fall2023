using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPManager_EthanH : MonoBehaviour
{

    public Image xpBar;
    public float xpAmount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GainXP(float xpGain)
    {
        xpAmount += xpGain;
        xpAmount = Mathf.Clamp(xpAmount, 0, 10);

        xpBar.fillAmount = xpAmount / 10f;
    }

}
