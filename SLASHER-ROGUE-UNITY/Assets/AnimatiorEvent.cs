using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatiorEvent : MonoBehaviour
{
    public UnityEvent AttackEvent;

    public void Attack()
    {
        AttackEvent.Invoke();
    }
}
