using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerInputControls inputControls;

    private void Awake()
    {
        inputControls = new PlayerInputControls();
    }

    private void OnEnable()
    {
        inputControls.MENU.Enable();
    }

    private void OnDisable()
    {
        inputControls.MENU.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inputControls.MENU.QUIT.IsPressed())
        {
            Application.Quit();
        }
    }
}
