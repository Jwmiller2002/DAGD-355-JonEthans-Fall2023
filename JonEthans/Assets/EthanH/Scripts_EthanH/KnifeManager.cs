using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeManager : MonoBehaviour
{

    public Image knife1;
    public Image knife2;
    public Image knife3;
    public int knifeAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PlayerThrow_NotEthan>().knifeAmount == 0)
        {
            knife1.GetComponent<Image>().enabled = false;
            knife2.GetComponent<Image>().enabled = false;
            knife3.GetComponent<Image>().enabled = false;
        }
        else if(GetComponent<PlayerThrow_NotEthan>().knifeAmount == 1)
        {
            knife1.GetComponent<Image>().enabled = true;
            knife2.GetComponent<Image>().enabled = false;
            knife3.GetComponent<Image>().enabled = false;
        }
        else if (GetComponent<PlayerThrow_NotEthan>().knifeAmount == 2)
        {
            knife1.GetComponent<Image>().enabled = true;
            knife2.GetComponent<Image>().enabled = true;
            knife3.GetComponent<Image>().enabled = false;
        }
        else if (knifeAmount == 3)
        {
            knife1.GetComponent<Image>().enabled = true;
            knife2.GetComponent<Image>().enabled = true;
            knife3.GetComponent<Image>().enabled = true;
        }
    }
}
