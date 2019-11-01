using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frame2 : MonoBehaviour
{
    public Text height,width;
    
    public void OnNext()
    {
        

        PlayerPrefs.SetInt("Height", System.Convert.ToInt32(height.text));
        PlayerPrefs.SetInt("Width", System.Convert.ToInt32(width.text));

        Debug.Log(PlayerPrefs.GetInt("Height") +" " + PlayerPrefs.GetInt("Width"));
    }

}
