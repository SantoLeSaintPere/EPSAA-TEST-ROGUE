using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public int damage = 1;
    public float attackRange;

    public AnimationClip attackClip;
    public float timerToRedoAttack = 0.35f;

    public Vector3 offset;

    public LayerMask enemyMask;
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
        Collider[] hitEnemy = Physics.OverlapSphere(transform.position, attackRange, enemyMask);
        foreach(Collider collider in hitEnemy)
        {
            Debug.Log("HIT" + damage);
            collider.GetComponent<EnemyHealthManager>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + offset, attackRange);
    }
}
