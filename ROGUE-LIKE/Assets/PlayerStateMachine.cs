using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [HideInInspector]
    public PlayerInputReader inputReader;
    [HideInInspector]
    public CharacterController characterController;
    [HideInInspector]
    public PlayerGroundDetector groundDetector;

    public float speed;
    Transform body;
    // Start is called before the first frame update
    void Start()
    {
        inputReader = GetComponent<PlayerInputReader>();
        characterController = GetComponent<CharacterController>();
        groundDetector = GetComponent<PlayerGroundDetector>();

        body = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(inputReader.isMoving)
        {
            if(groundDetector.isGrounded)
            {

                characterController.Move((inputReader.direction) * speed * Time.deltaTime);
            }
            body.rotation = Quaternion.LookRotation(inputReader.direction, Vector3.up);
        }
    }
}
