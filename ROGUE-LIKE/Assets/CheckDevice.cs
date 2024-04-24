using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CheckDevice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            gameObject.SetActive(false);
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            gameObject.SetActive(true);
        }

        if(EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android)
        {
            gameObject.SetActive(true);
        }

        else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
