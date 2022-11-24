using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootProjectile : MonoBehaviour
{
    [SerializeField] private GameObject pfBullet;

    private void Awake()
    {
        GetComponent<AimPlayerWeapon>().OnShoot += PlayerShootProjectile_OnShoot;
    }

    private void PlayerShootProjectile_OnShoot(object sender, AimPlayerWeapon.OnShootEventArgs e)
    {
        GameObject bulletTransform = Instantiate(pfBullet, e.gunEndPosition, Quaternion.identity);

        Vector3 shotDir = (e.shootPosition - e.gunEndPosition).normalized;
        bulletTransform.GetComponent<Bullet>().Setup(shotDir);
    }
}
