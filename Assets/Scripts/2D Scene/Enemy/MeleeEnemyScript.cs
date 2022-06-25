using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyScript : MeleeAttackScript
{

    public bool isAttacking { get; private set; }

    private new void Update()
    {
        if (ObjectInSight() && cooldownTimer >= attackCooldown)
        {
            isAttacking = true;
            Attack();
        }

        base.Update();
    }

    public void FinishAttacking()
    {
        isAttacking = false;
    }

}
