using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPManager_EthanH : MonoBehaviour
{

    public Image xpBar;
    public float xpAmount;
    public float nextLevelAmount;
    public float level = 0;
    public int knifeNumber = 1;
    public TMP_Text levelDisplay;

    // Start is called before the first frame update
    void Start()
    {
        nextLevelAmount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        levelDisplay.SetText(level.ToString());
        if (xpAmount >= nextLevelAmount)
        {
            level++;
            ResetBar();
        }
        if (level == 4)
        {
            knifeNumber = 2;
        }
    }
    public void GainXP(float xpGain)
    {
        xpAmount += xpGain;
        xpAmount = Mathf.Clamp(xpAmount, 0, nextLevelAmount);

        xpBar.fillAmount = xpAmount / nextLevelAmount;
    }

    public void ResetBar()
    {
        xpAmount = 0;
        nextLevelAmount *= 2;
    }

}
