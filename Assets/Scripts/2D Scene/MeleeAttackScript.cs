using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackScript : MonoBehaviour
{
    [SerializeField] protected float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private AudioClip attackSound;
    protected float cooldownTimer = float.MaxValue;
    protected Animator animator;

    protected HealthScript objectHealth;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    protected void Attack()
    {
        SoundManager.instace.PlaySound(attackSound);
        cooldownTimer = 0;
        animator.SetTrigger("attack");
    }

    public void DamageHealthObject()
    {
        if (ObjectInSight())
            objectHealth.TakeDamage(damage);
    }

    protected bool ObjectInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0,
            Vector2.left,
            0,
            hitLayer
            );
        if (hit.collider != null)
            objectHealth = hit.transform.GetComponent<HealthScript>();
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
            );
    }
}
