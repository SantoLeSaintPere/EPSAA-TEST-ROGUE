using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MobilButtonManager : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
