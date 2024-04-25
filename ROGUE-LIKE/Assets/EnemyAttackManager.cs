using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    [Header("DETECTION ZONE")]
    public Vector3 offset;
    public LayerMask playerLayer;
    public float attackDetectionZone;


    [Header("ATTACK SET UP")]
    public AnimationClip attackClip;
    public float attackRange;
    public int damage;

    [Header("ATTACK-POINT / SHOOT-POINT")]
    public Transform attackPoint;
    public Transform shootPointHolder;

    [Header("IF SHOOTER")]
    public GameObject bullet;


    [HideInInspector]
    public bool isInAttackZone;


    EnemyStateMachine stateMachine;
    bool isShooter;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<EnemyStateMachine>();
        if(stateMachine.enemyType == EnemyType.shooter)
        {
            isShooter = true;
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isInAttackZone = Physics.CheckSphere(transform.position + offset, attackDetectionZone, playerLayer);

        if(isShooter && isInAttackZone)
        {
            shootPointHolder.rotation = Quaternion.LookRotation(transform.position - player.position, Vector3.up);
        }
    }

    public void Shoot()
    {
        GameObject bulletInst = Instantiate(bullet, attackPoint.position, attackPoint.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + offset, attackDetectionZone);
    }
}
