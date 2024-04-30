using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    [Header("DETECTION ZONE")]
    public Vector3 offset;
    public LayerMask playerLayer;
    public float attackDetectionZone;
    public float stopingDistance;


    [Header("ATTACK SET UP")]
    public AnimationClip attackClip;
    public float attackRange;
    public int damage;

    [Header("ATTACK-POINT")]
    public Transform attackPoint;

    [Header("IF SHOOTER")]
    public EnemyShooterManager shooterManager;

    [HideInInspector]
    public bool isInAttackZone;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isInAttackZone = Physics.CheckSphere(transform.position + offset, attackDetectionZone, playerLayer);
    }

    public void Shoot()
    {
        GameObject bulletInst = Instantiate(shooterManager.bullet, attackPoint.position, attackPoint.rotation);
        bulletInst.GetComponent<Bullet>().damage = damage;
        bulletInst.GetComponent<Bullet>().speed = shooterManager.speed;
        bulletInst.GetComponent<Bullet>().timeToDestroy = shooterManager.timeToDestroy;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + offset, attackDetectionZone);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + offset, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere (transform.position, stopingDistance);
    }
}

[Serializable]
public class EnemyShooterManager
{
    public float fireRate = 1f;
    public float coolDown = 0.5f;

    public Transform shootPointHolder;
    public GameObject muzzle;

    [Header("BULLET")]
    public GameObject bullet;
    public float speed = 2.5f;
    public float timeToDestroy = 3f;

    
}
