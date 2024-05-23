using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangesManager : MonoBehaviour
{
    [Header("DETECTION")]
    public Vector3 detectionSize;
    public bool isInDetectionRange;
    public LayerMask playerLayer;
    [Header("PLAYER IN ATTACK RANGE")]
    public Vector3 attackSize;
    public bool isInAttackRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isInDetectionRange = Physics.CheckBox(transform.position, detectionSize / 2, Quaternion.identity, playerLayer) ;
        isInAttackRange = Physics.CheckBox(transform.position, attackSize / 2, Quaternion.identity, playerLayer) ;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, detectionSize);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, attackSize);
    }
}
