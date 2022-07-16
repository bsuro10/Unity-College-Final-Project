using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiePatrolScript : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5;
    public float lookRadius = 8f;
    public float health;

    private int m_currentWaypointIndex;
    private Vector3 m_target, m_moveDirection;
    private Animator m_animator;
    private bool m_isWalking = true;
    private bool m_isDead { get; set; }  = false;
    private bool m_isAttacking = false;
    private NavMeshAgent agent;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!m_isDead)
        {
            Vector3 playerPosition = SceneManagerScript.Instance.playerScript.transform.position;
            float distance = Vector3.Distance(playerPosition, transform.position);
            if (distance <= lookRadius)
            {
                agent.SetDestination(playerPosition);
                m_isWalking = true;
                if (distance <= agent.stoppingDistance)
                {
                    FaceTarget(playerPosition);
                    AttackPlayer();
                }
                else
                {
                    m_isAttacking = false;
                }
            }
            else
            {
                m_isAttacking = false;
                if (m_isWalking)
                    WalkTowardsNextWayPoint();
            }
        }
        m_animator.SetBool("isWalking", m_isWalking);
        m_animator.SetBool("isAttacking", m_isAttacking);
        m_animator.SetBool("isDead", m_isDead);
    }

    void FaceTarget(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    IEnumerator WaitOnWaypoint()
    {
        m_isWalking = false;
        yield return new WaitForSeconds(5);
        m_isWalking = true;
    }

    void AttackPlayer()
    {
        if (!m_isDead)
        {
            m_isWalking = false;
            m_isAttacking = true;
        }
    }

    void HitPlayerSuccess()
    {
        SceneManagerScript.Instance.playerScript.KillPlayer();
    }

    private void WalkTowardsNextWayPoint()
    {
        m_target = waypoints[m_currentWaypointIndex].position;
        float distance = Vector3.Distance(m_target, transform.position);
        if (distance <= agent.stoppingDistance)
        {
            m_currentWaypointIndex = ++m_currentWaypointIndex % waypoints.Length;
            StartCoroutine(WaitOnWaypoint());
        }
        FaceTarget(m_target);
        agent.SetDestination(m_target);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= SceneManagerScript.Instance.playerScript.attackDamage;
            if (health <= 0)
                StartCoroutine(KillEnemy());
        }
    }

    IEnumerator KillEnemy()
    {
        m_isDead = true;
        agent.speed = 0;
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(5f);
        gameObject.tag = "DeadEnemy";
    }

}
