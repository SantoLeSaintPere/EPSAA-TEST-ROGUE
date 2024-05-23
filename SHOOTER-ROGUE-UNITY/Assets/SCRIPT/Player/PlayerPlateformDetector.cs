using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlateformDetector : MonoBehaviour
{
    PlayerInputReader inputReader;

    [Header("TOP")]
    public Vector3 offset;
    public float range;
    [Header("BOTTOM")]
    public Vector3 offset2;
    public float range2;

    public LayerMask platformMask;
    public bool isOnPlateform;
    // Start is called before the first frame update
    void Start()
    {
        inputReader = GetComponent<PlayerInputReader>();
    }

    // Update is called once per frame
    void Update()
    {
        isOnPlateform = Physics.CheckSphere(transform.position + offset2, range2, platformMask);

        if (inputReader.isJumping)
        {
            Collider[] topPlat = Physics.OverlapSphere(transform.position + offset, range, platformMask);
            foreach (Collider col in topPlat)
            {
                col.GetComponent<PlaterformBehaviour>().DeactivePlateForm();
            }
        }

        if(isOnPlateform && inputReader.isCrunching)
        {

            Collider[] downPlat = Physics.OverlapSphere(transform.position + offset2, range2, platformMask);
            foreach (Collider col in downPlat)
            {
                col.GetComponent<PlaterformBehaviour>().DeactivePlateForm();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + offset, range);
        Gizmos.DrawWireSphere(transform.position + offset2, range2);
    }
}
