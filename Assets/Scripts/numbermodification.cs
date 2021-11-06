using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numbermodification : MonoBehaviour
{


    public GameObject number;
    public int max;
    public int min;
    

    public void Plus()
    {
        if (int.Parse(number.GetComponent<UnityEngine.UI.Text>().text) < max)
        {
            number.GetComponent<UnityEngine.UI.Text>().text = (int.Parse(number.GetComponent<UnityEngine.UI.Text>().text) + 1).ToString();
        }

    }
    public void Minus()
    {
        if (int.Parse(number.GetComponent<UnityEngine.UI.Text>().text) > min)
        {
            number.GetComponent<UnityEngine.UI.Text>().text = (int.Parse(number.GetComponent<UnityEngine.UI.Text>().text) - 1).ToString();
        }
    }
}
