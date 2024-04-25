using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldManager : MonoBehaviour
{
    PlayerInputReader inputReader;
    public GameObject[] lifeUi;
    public float recoveryTime;

    //[HideInInspector]
    public bool canUseShield;

    [HideInInspector]
    public int health, maxHealth;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        inputReader = GetComponent<PlayerInputReader>();

        maxHealth = lifeUi.Length;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        canUseShield = health > 0 && inputReader.isHoldingShield;

        if (health ==0)
        {
            timer += Time.deltaTime;
            if (timer >= recoveryTime)
            {
                foreach (GameObject go in lifeUi)
                {
                    go.SetActive(true);
                }
                health = maxHealth;
            }
        }
    }
    public void TakeShieldDamage(int damage)
    {
        lifeUi[health - 1].SetActive(false);
        health -= damage;
    }
}
