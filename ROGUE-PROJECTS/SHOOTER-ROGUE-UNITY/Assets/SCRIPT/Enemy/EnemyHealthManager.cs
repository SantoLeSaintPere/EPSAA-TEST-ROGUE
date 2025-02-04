using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public Image healthBar;
    public float health;
    public float maxHealth = 10f;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }


}
