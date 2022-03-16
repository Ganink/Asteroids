using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private static AttackManager instance;

    public static AttackManager Getinstance () {
        return instance;
    }

    public static void Setinstance (AttackManager value) {
        instance = value;
    }

    public AttackManager () {
        if (Getinstance() == null) {
            Setinstance(this);
        }
    }

    private void Update () {
        if (Input.GetButtonDown("Fire1")) {
            FireBullet();
        }
    }

    public void FireBullet () {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * Constants.BULLET_SPEED, ForceMode2D.Impulse);
        Destroy(bullet, Constants.BULLET_TIME_DESTROY);
    }
}
