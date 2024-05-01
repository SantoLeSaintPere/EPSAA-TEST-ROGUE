using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MobilButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isMobil;
    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            gameObject.SetActive(false);
            isMobil = false;
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            gameObject.SetActive(true);
            isMobil = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
