using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject frame;
    public void OnPlay()
    {
        Canvas.SetActive(true);
        frame.SetActive(false);
    }
    public void  OnQuit()
    {
    Application.Quit();
    Debug.Log("Quit");
    }
}
