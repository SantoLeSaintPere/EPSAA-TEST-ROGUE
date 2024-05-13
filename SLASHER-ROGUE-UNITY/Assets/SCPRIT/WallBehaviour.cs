using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    public float speed = 0.5f;
    SpriteRenderer spriteRenderer;
    public float alpha;

    float originalAlpha;
    bool playerIn;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalAlpha = spriteRenderer.color.a;
        //GetComponent<MeshRenderer>().enabled = false;
    }

    private void Update()
    {
        if(playerIn)
        {
            float a = Mathf.MoveTowards(spriteRenderer.color.a, alpha, speed * Time.deltaTime);
            spriteRenderer.color = new Color(1, 1, 1, a);
        }

        else
        {

            float b = Mathf.MoveTowards(spriteRenderer.color.a, originalAlpha, speed * Time.deltaTime);
            spriteRenderer.color = new Color(1, 1, 1, b);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerIn = false;
        }
    }
}
