using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletDamage;
    public float bulletSpeed;
    public Vector3 bulletDir;
    public float bulletTimeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(bulletDir * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, bulletTimeToDestroy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealthManager>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }

        if(!other.CompareTag("Player"))
        {
            Destroy(gameObject);    
        }
    }
}
