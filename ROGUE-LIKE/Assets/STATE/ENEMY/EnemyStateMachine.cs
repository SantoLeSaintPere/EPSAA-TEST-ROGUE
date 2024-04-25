using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    melee, shooter, bomb
}
public class EnemyStateMachine : StateMachine
{
    public EnemyType enemyType;
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
