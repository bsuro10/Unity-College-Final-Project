using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{

    [SerializeField] private float attackCooldown;

    private Animator animator;
    private Player2DMovementScript playerMovement;
    private float cooldownTimer = float.MaxValue;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<Player2DMovementScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && 
            cooldownTimer > attackCooldown &&
            playerMovement.CanAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
        cooldownTimer = 0;
    }

}
