using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolScript : MonoBehaviour
{
    public Transform[] waypoints;

    private int m_currentWaypointIndex;
    private Vector3 m_target;
    private Animator m_animator;
    private NavMeshAgent m_agent;
    private bool m_isWalking = true;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (m_isWalking)
        {
            WalkTowardsNextWayPoint();
        }
        m_animator.SetBool("isWalking", m_isWalking);
    }

    private void WalkTowardsNextWayPoint()
    {
        m_target = waypoints[m_currentWaypointIndex].position;
        float distance = Vector3.Distance(m_target, transform.position);
        if (distance <= m_agent.stoppingDistance)
        {
            m_currentWaypointIndex = ++m_currentWaypointIndex % waypoints.Length;
            StartCoroutine(WaitOnWaypoint());
        }
        FaceTarget(m_target);
        m_agent.SetDestination(m_target);
    }

    IEnumerator WaitOnWaypoint()
    {
        m_isWalking = false;
        yield return new WaitForSeconds(5);
        m_isWalking = true;
    }

    void FaceTarget(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
