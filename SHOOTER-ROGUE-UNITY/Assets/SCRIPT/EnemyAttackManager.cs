using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    public float attackRange;
    public Vector3 offset;

    public LayerMask playerMask;
    public bool isContact;

    public int damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        if(isContact && other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealthManager>().TakeDamage(damage);
        }
    }

    public void Attack()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(transform.position + offset, attackRange, playerMask);
        foreach (Collider collider in hitPlayer)
        {
            collider.GetComponent<PlayerHealthManager>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + offset, attackRange);
    }
}
