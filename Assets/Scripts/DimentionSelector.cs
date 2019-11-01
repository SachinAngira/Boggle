using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DimentionSelector : MonoBehaviour
{
    public Text Height;
    int a;
    void Start()
    {
        a = 0;
    }
    

    public void OnAdd()
    {
        a++;
        Height.text = a.ToString();
    }
    
    public void OnMinus()
    {
        if (a > 0)
        {
            a--;
            Height.text = a.ToString();
        }
    }
    
}
