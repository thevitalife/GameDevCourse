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

    private float lastShootTime = float.MinValue;

    public void Shoot()
    {
        if (Time.time - rechargeTime > lastShootTime)
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.Init(bulletPoint.position, bulletPoint.forward);
            lastShootTime = Time.time;
        }
    }
}
