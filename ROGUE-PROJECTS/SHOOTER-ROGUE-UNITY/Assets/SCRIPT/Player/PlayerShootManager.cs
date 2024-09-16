using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootManager : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject Bullet;


    [Header("BULLET SET UP")]
    public int bulletDamage = 1;
    public float bulletSpeed = 5;
    public Vector3 bulletDir;
    public float bulletTimeToDestroy = 2;

    [Header("WEAPONNERY")]
    public GameObject gunHand;
    public GameObject gunBack;

    [Header("REVOLVER")]
    public float gunTimeToHide;
    [HideInInspector]
    public bool gunOff;


    [Header("MINI-GUN")]
    public float fireRate = 1;
    [HideInInspector]
    public float shootTimer;
    // Start is called before the first frame update
    void Start()
    {
        shootTimer = fireRate;
        HideGun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void HideGun()
    {
        gunHand.SetActive(false);
        gunBack.SetActive(true);
    }


    public void ShowGun()
    {
        gunHand.SetActive(true);
        gunBack.SetActive(false);
    }

    public void Shoot()
    {
        GameObject bulletInst = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        bulletInst.GetComponent<PlayerBullet>().bulletDamage = bulletDamage;
        bulletInst.GetComponent<PlayerBullet>().bulletSpeed = bulletSpeed;



        ///////TRANSFORM 
        bulletInst.GetComponent<PlayerBullet>().bulletDir = shootPoint.right;
        bulletInst.GetComponent<PlayerBullet>().bulletTimeToDestroy = bulletTimeToDestroy;

        StartCoroutine(ShowGunCoroutine());

    }

    IEnumerator ShowGunCoroutine()
    {
        ShowGun();
        gunOff = true;
        yield return new WaitForSeconds(gunTimeToHide);
        HideGun();
        StopAllCoroutines();
        gunOff = false;
    }
}
