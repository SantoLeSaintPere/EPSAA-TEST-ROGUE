using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    [HideInInspector]
    public PlayerInputControls inputControls;
    public Vector3 dir;
    public float dirX;
    public bool isMoving;

    public bool isShooting;

    private void Awake()
    {
        inputControls = new PlayerInputControls();
    }

    public void EnablePlayer()
    {
        inputControls.Player.Enable();
    }

    public void DisablePlayer()
    {
        inputControls.Player.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        EnablePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = inputControls.Player.MOVE.ReadValue<float>();
        dir = new Vector3(dirX, 0, 0);
        isMoving = dirX !=0;

        isShooting = inputControls.Player.SHOOT.IsPressed();
    }

}
