using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public GameObject[] life;
    [HideInInspector]
    public int health;
    [HideInInspector]
    public int maxHealth;

    EnemyStateMachine stateMachine;

    public GameObject[] objectToDrop;

    PlayerHealthManager playerHealthManager;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<EnemyStateMachine>();
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
        maxHealth = life.Length;
        health = maxHealth;
    }

    private void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        stateMachine.NextState(new EnemyHitState(stateMachine));
        life[health-1].SetActive(false);
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("DEATH STATE");
            if(playerHealthManager.health < 3)
            {

                Instantiate(objectToDrop[0], transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

    }
}
