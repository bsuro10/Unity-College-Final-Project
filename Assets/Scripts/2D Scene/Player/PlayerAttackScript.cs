using UnityEngine;

public class PlayerAttackScript : MeleeAttackScript
{
    private Player2DMovementScript playerMovement;

    private new void Awake()
    {
        base.Awake();
        playerMovement = GetComponent<Player2DMovementScript>();
    }

    private new void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && 
            cooldownTimer > attackCooldown &&
            playerMovement.CanAttack())
            Attack();

        base.Update();
    }

}
