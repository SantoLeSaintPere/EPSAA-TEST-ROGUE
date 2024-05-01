using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiOptionManager : MonoBehaviour
{
    MobilButtonManager mobilButtonManager;

    public GameObject optionPanel;
    public Toggle useStickToggle;
    public GameObject stickPanel, buttonPanel;

    bool useStick;
    bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        mobilButtonManager = FindObjectOfType<MobilButtonManager>();
        if(mobilButtonManager.isMobil)
        {
            useStickToggle.gameObject.SetActive(true);

            stickPanel.SetActive(true);
            buttonPanel.SetActive(false);

        }



        else
        {
            useStickToggle.gameObject.SetActive(false);
        }
        
        optionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OptionPanelOn()
    {
        optionPanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void OptionPanelOff()
    {
        optionPanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void UseStick(bool use)
    {

        if (use)
        {
            stickPanel.SetActive(true);
            buttonPanel.SetActive(false);
        }

        else
        {
            stickPanel.SetActive(false);
            buttonPanel.SetActive(true);
        }
    }
}
