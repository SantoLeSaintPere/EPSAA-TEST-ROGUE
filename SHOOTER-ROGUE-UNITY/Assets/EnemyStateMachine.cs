using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [HideInInspector]
    public EnemyGroundDetector groundDetector;
    [HideInInspector]
    public EnemyShootManager shootManager;
    [HideInInspector]
    public EnemyRangesManager rangesManager;

    [Header("BODY + HOLDER")]
    public float angleDesired;
    public Transform body, holder;
    // Start is called before the first frame update
    void Start()
    {
        groundDetector = GetComponent<EnemyGroundDetector>();
        shootManager = GetComponent<EnemyShootManager>();
        rangesManager = GetComponent<EnemyRangesManager>();
    }
}
