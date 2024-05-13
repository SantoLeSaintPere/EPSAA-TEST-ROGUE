using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    PlayerHealthManager healthManager;

    private void Start()
    {
        healthManager = FindObjectOfType<PlayerHealthManager>();
    }
    public void GiveLife()
    {
        
        if(healthManager.health < healthManager.maxHealth)
        {
            healthManager.GiveLife();
            Destroy(gameObject);
        }
    }
}
