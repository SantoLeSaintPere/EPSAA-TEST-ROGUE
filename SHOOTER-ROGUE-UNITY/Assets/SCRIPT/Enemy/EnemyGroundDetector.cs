using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundDetector : MonoBehaviour
{
    public float range = 2f;
    public Transform groundDetector;
    public bool isGrounded;
    public LayerMask groundMask;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(groundDetector.position, -transform.up, range, groundMask);
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(groundDetector.position, -transform.up * range, Color.green);
    }
}
