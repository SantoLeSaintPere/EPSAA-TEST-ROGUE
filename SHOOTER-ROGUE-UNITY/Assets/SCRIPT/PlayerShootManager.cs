using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootManager : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject Bullet;
    public float fireRate = 1;


    [Header("BULLET SET UP")]
    public float bulletDamage = 1;
    public float bulletSpeed = 5;
    public Vector3 bulletDir;
    public float bulletTimeToDestroy = 2;

    [HideInInspector]
    public float shootTimer;
    // Start is called before the first frame update
    void Start()
    {
        shootTimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        GameObject bulletInst = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        bulletInst.GetComponent<PlayerBullet>().bulletDamage = bulletDamage;
        bulletInst.GetComponent<PlayerBullet>().bulletSpeed = bulletSpeed;



        ///////TRANSFORM 
        bulletInst.GetComponent<PlayerBullet>().bulletDir = shootPoint.right;
        bulletInst.GetComponent<PlayerBullet>().bulletTimeToDestroy = bulletTimeToDestroy;

    }
}
