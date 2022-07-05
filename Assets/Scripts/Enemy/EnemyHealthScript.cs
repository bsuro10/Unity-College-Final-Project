using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private Behaviour[] components;

    private bool m_isDead = false;
    private bool m_isAttacking = false;
    private Animator m_animator;
    private Rigidbody m_rigidBody;
    private Collider m_collider;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody>();
        m_collider = GetComponent<Collider>();
    }

    private void Update()
    {
        m_animator.SetBool("isAttacking", m_isAttacking);
        m_animator.SetBool("isDead", m_isDead);
    }

    public void HitPlayerSuccess()
    {
        SceneManagerScript.Instance.playerScript.KillPlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= SceneManagerScript.Instance.playerScript.attackDamage;
            if (health <= 0 && !m_isDead)
            {
                m_isDead = true;
                m_rigidBody.isKinematic = true;
                m_collider.enabled = false;
                gameObject.tag = "DeadEnemy";
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
            }
        }
    }

    public void AttackPlayer()
    {
        if (!m_isDead)
            m_isAttacking = true;
    }

}
