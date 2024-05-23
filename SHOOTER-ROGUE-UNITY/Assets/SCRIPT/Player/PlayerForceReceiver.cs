using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForceReceiver : MonoBehaviour
{
    public float gravityMultiplier = -9;

    [Header("Jump")]
    public float jumpForce;
    public float jumpTime;

    public float landFrimeRate = 30;

    [Header("Fall")]
    public Vector3 lastPos;
    public float fallMaxTime = 3;
}
