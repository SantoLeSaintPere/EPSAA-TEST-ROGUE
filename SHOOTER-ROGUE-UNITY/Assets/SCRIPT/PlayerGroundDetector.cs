using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    public float range = 2f, feetRange;
    public Transform groundDetector, feetPos;
    public bool canWalkGround, isGrounded;
    public LayerMask groundMask;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        canWalkGround = Physics.Raycast(groundDetector.position, -transform.up, range, groundMask);
        isGrounded = Physics.CheckSphere(feetPos.position , feetRange, groundMask);
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(groundDetector.position, -transform.up * range, Color.green);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(feetPos.position, feetRange);
    }
}
