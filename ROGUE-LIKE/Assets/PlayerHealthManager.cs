using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    GameManager gameManager;
    public GameObject[] life;

    [HideInInspector]
    public int health;
    [HideInInspector]
    public int maxHealth;
    [HideInInspector]
    public bool hitted;
    PlayerStateMachine stateMachine;
    public AnimationClip hitClip;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
        gameManager = FindObjectOfType<GameManager>();
        maxHealth = life.Length;
        health = maxHealth;
    }
    public void GiveLife()
    {
        life[health].SetActive(true);
        health+=1;
    }

    public void TakeDamage(int damage)
    {
        if(!hitted)
        {
            timer = 0;
            life[health - 1].SetActive(false);
            health -= damage;
            stateMachine.NextState(new PlayerHitState(stateMachine));
        }

        if(health <= 0)
        {

            life[0].SetActive(false);
            Debug.Log("DEATH STATE");
            gameManager.Reload();
        }
    }
}
