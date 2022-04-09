using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompShooter : WeaponBase
{
    [SerializeField] Transform shootpoint;
    [SerializeField] Proyectile model_pojectile;

    public override void ExecuteAttack()
    {
        var bullet = GameObject.Instantiate(model_pojectile);
        bullet.Move(shootpoint.position, shootpoint.forward);
    }
}
