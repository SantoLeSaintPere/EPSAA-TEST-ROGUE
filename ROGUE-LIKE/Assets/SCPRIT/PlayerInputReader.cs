using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    public PlayerInputControls inputcontrols;
    public Vector3 direction;
    public bool isMoving;
    public bool isHoldingAttack;
    public bool isHoldingShield;
    private void Awake()
    {
        inputcontrols = new PlayerInputControls();
    }

    private void OnEnable()
    {
        inputcontrols.Player.Enable();
    }

    private void OnDisable()
    {
        inputcontrols.Player.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = inputcontrols.Player.MOVE.ReadValue<Vector2>();
        direction = new Vector3(move.x,0, move.y);
        direction.Normalize();
        isMoving = direction.sqrMagnitude > 0;
        isHoldingAttack = inputcontrols.Player.ATTACK.IsPressed();
        isHoldingShield = inputcontrols.Player.DODGE.IsPressed();

        if(isHoldingAttack )
        {
            Debug.Log("ATTACK");
        }
    }
}
