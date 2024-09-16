using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerStayEvenet : MonoBehaviour
{
    public UnityEvent ontrigger;
    PlayerInputReader inputReader;

    private void Start()
    {
        inputReader = FindObjectOfType<PlayerInputReader>();
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player") && inputReader.isHoldingAttack)
        {
            ontrigger.Invoke();
        }
    }
}
