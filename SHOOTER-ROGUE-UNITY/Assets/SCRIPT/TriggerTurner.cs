using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum AttractionType
{
    normal, up,downside ,down
}
public class TriggerTurner : MonoBehaviour
{
    GameObject player;

    Transform spawnPoint;
    public AttractionType attractionType;
    bool locked;

    private void Start()
    {
        spawnPoint = transform.GetChild(0);
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !locked)
        {

            if (attractionType == AttractionType.normal)
            {
                player.GetComponent<PlayerDirectionManager>().normalDir = true;
                player.GetComponent<PlayerDirectionManager>().rightDir = false;
                player.GetComponent <PlayerDirectionManager>().upDir = false;
                player.GetComponent<PlayerDirectionManager>().leftDir = false;
            }

            if (attractionType == AttractionType.up)
            {
                player.GetComponent<PlayerDirectionManager>().normalDir = false;
                player.GetComponent<PlayerDirectionManager>().rightDir = true;
                player.GetComponent<PlayerDirectionManager>().upDir = false;
                player.GetComponent<PlayerDirectionManager>().leftDir = false;
            }


            if (attractionType == AttractionType.downside)
            {
                player.GetComponent<PlayerDirectionManager>().normalDir = false;
                player.GetComponent<PlayerDirectionManager>().rightDir = false;
                player.GetComponent<PlayerDirectionManager>().upDir = true;
                player.GetComponent<PlayerDirectionManager>().leftDir = false;
            }


            if (attractionType == AttractionType.down)
            {
                player.GetComponent<PlayerDirectionManager>().normalDir = false;
                player.GetComponent<PlayerDirectionManager>().rightDir = false;
                player.GetComponent<PlayerDirectionManager>().upDir = false;
                player.GetComponent<PlayerDirectionManager>().leftDir = true;
            }

            player.GetComponent<PlayerStateMachine>().NextState(new PlayerNoMoveState(player.GetComponent<PlayerStateMachine>()));
            player.transform.position = spawnPoint.position;
            Invoke("CanMove", 0.05f);


            if (!player.GetComponent<PlayerStateMachine>().autoRun)
            {
                locked = true;
            }
        }
    }

    public void CanMove()
    {
        player.GetComponent<PlayerStateMachine>().NextState(new PlayerMoveState(player.GetComponent<PlayerStateMachine>()));
    }
}

