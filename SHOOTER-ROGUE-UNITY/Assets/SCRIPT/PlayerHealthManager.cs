using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public GameObject[] life;

    [HideInInspector]
    public int health;
    [HideInInspector]
    public int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = life.Length;
        health = maxHealth;
    }
    public void GiveLife()
    {
        life[health].SetActive(true);
        health += 1;
    }

    public void TakeDamage()
    {

        if (health <= 0)
        {

            life[0].SetActive(false);
            Debug.Log("DEATH STATE");
        }


        else
        {
            life[health - 1].SetActive(false);
            health --;
        }
    }
}
