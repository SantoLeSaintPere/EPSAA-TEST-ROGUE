using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public int damage = 1;
    public float attackRange;

    public AnimationClip[] attackClip;
    public float[] frameToCombo;

    public Vector3 offset;

    public LayerMask enemyMask;
    [HideInInspector]
    public int attackCount;
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
        Collider[] hitEnemy = Physics.OverlapSphere(transform.position + offset, attackRange, enemyMask);
        foreach(Collider collider in hitEnemy)
        {
            Debug.Log(attackCount);
            if(attackCount == attackClip.Length-1)
            {
                Debug.Log("COMBO-DAMAGE");
                if(collider.GetComponent<EnemyHealthManager>() != null)
                {
                    collider.GetComponent<EnemyHealthManager>().TakeDamage(damage * 2);
                }
            }

            else
            {
                if (collider.GetComponent<EnemyHealthManager>() != null)
                {
                    collider.GetComponent<EnemyHealthManager>().TakeDamage(damage);
                }
            }

            if(collider.GetComponent<HealthBox>() != null)
            {
                collider.GetComponent<HealthBox>().GiveLife();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + offset, attackRange);
    }
}
