using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterformBehaviour : MonoBehaviour
{
    public float time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivePlateForm()
    {
        StartCoroutine(DeactivePlateFormCoroutine());
    }


    IEnumerator DeactivePlateFormCoroutine()
    {
        GetComponent<MeshCollider>().enabled = false;
        yield return new WaitForSeconds(time);
        GetComponent<MeshCollider>().enabled = true;
        StopAllCoroutines();
    }
}
