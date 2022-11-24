using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Shooting : MonoBehaviour
{
    [SerializeField] private AimPlayerWeapon playerAimWeapon;
    [SerializeField] private Material weaponTracerMaterial;

    private void Start()
    {
        playerAimWeapon.OnShoot += PlayerAimWeapon_OnShoot;
    }

    private void PlayerAimWeapon_OnShoot(object sender, AimPlayerWeapon.OnShootEventArgs e)
    {
    }

    
}
