using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private Transform bulletPoint;

    [SerializeField]
    private float rechargeTime = 1;

    private void Start()
    {
        StartCoroutine(StartShooting());
    }

    public void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab);
        bullet.Init(bulletPoint.position, bulletPoint.forward);
    }

    private IEnumerator StartShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(rechargeTime);
            Shoot();
        }
    }
}
