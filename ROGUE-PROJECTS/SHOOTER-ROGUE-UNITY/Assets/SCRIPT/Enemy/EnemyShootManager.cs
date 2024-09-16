using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootManager : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject Bullet;
    public float fireRate = 1;
    [Header("BULLET SET UP")]
    public int bulletDamage = 1;
    public float bulletSpeed = 2.5f;
    public Vector3 bulletDir;
    public float bulletTimeToDestroy = 1;

    [HideInInspector]
    public float shootTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Shoot()
    {
        GameObject bulletInst = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        bulletInst.GetComponent<EnemyBullet>().bulletDamage = bulletDamage;
        bulletInst.GetComponent<EnemyBullet>().bulletSpeed = bulletSpeed;



        ///////TRANSFORM 
        bulletInst.GetComponent<EnemyBullet>().bulletDir = -shootPoint.right;
        bulletInst.GetComponent<EnemyBullet>().bulletTimeToDestroy = bulletTimeToDestroy;

    }
}
