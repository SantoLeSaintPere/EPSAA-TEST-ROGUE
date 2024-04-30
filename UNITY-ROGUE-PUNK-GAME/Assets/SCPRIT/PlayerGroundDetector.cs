using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    public LayerMask groundMask;
    public float range = 2f;
    public Transform groundDetectorHolder;
    Transform groundDetector;

    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        groundDetector = groundDetectorHolder.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(groundDetector.position, Vector3.down * range, Color.green);

        isGrounded = Physics.Raycast(groundDetector.position, Vector3.down, range, groundMask);
    }
}
