using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public TMP_Text text;
    public Image healthBar;
    [HideInInspector]
    public int health;
    public int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        text.text = health.ToString(); 
    }
    public void GiveLife()
    {
        health += 1;
    }

    public void TakeDamage(int damage)
    {

        if (health <= 0)
        {

            Debug.Log("DEATH STATE");
        }


        else
        {
            health -=damage;
        }
    }
}
