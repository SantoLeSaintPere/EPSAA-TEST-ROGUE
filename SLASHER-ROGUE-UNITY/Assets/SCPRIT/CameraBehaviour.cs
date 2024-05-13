using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Transform playerTarget;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTarget.position + offset;
    }
}
