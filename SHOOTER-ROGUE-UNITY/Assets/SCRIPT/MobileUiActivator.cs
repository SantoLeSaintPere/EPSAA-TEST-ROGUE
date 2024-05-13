using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUiActivator : MonoBehaviour
{
    public GameObject mobilPanel;
    public bool isMobil;
    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            mobilPanel.SetActive(false);
            isMobil = false;
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            mobilPanel.SetActive(true);
            isMobil = true;
        }
    }
}
