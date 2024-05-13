using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;

    public LayerMask enemyMask;
    public float attackTime = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        Collider[] hitEnemy = Physics.OverlapSphere(attackPoint.position, attackRange, enemyMask);
        foreach (Collider collider in hitEnemy)
        {
            Debug.Log(collider.name);
            collider.GetComponent<EnemyHealthManager>().DestroyEnemy();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
