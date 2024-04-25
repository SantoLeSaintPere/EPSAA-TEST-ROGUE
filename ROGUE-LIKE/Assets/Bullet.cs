using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    public float speed;
    public float timeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, timeToDestroy);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT");
        if (other.CompareTag("Player"))
        {
            if(other.GetComponent<PlayerShieldManager>().canUseShield)
            {
                other.GetComponent<PlayerShieldManager>().TakeShieldDamage(damage);
            }

            else
            {

                Debug.Log("HIT PLAYER");
                other.GetComponent<PlayerHealthManager>().TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
