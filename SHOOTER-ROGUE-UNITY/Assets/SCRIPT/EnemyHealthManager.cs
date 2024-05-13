using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    Image healthBar;
    public float health;
    public float maxHealth = 10f;

    private void Start()
    {
        health = maxHealth;
        healthBar = GetComponentInChildren<Image>();
    }

    private void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }


}
