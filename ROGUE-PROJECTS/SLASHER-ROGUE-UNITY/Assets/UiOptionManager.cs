using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiOptionManager : MonoBehaviour
{
    GameManager gameManager;
    MobilButtonManager mobilButtonManager;

    public GameObject optionPanel;
    public Toggle useStickToggle;
    public GameObject stickPanel, buttonPanel;

    bool useStick;
    [HideInInspector]
    public bool isPaused;
    public static bool isPausedStatic;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

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
        if(gameManager.inputControls.MENU.OPTIONS.WasPerformedThisFrame())
        {
            if(isPausedStatic)
            {
                isPausedStatic = false;
                OptionPanelOff();
            }

            else
            {
                isPausedStatic = true;
                OptionPanelOn();
            }
        }
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
            stickPanel.SetActive(false);
            buttonPanel.SetActive(true);
        }

        else
        {
            stickPanel.SetActive(true);
            buttonPanel.SetActive(false);
        }
    }
}
