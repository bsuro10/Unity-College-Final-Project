using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrapScript : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrowsPool;
    [SerializeField] private float attackDelay = 0;

    private float cooldownTimer;

    private void Awake()
    {
        cooldownTimer -= attackDelay;
    }

    private void Attack()
    {
        cooldownTimer = 0;
        int availableArrowIndexFromPool = FindArrowFromPool();
        arrowsPool[availableArrowIndexFromPool].transform.position = firePoint.position;
        arrowsPool[availableArrowIndexFromPool].GetComponent<EnemyProjectileScript>().ActivateProjectile();
    }

    private int FindArrowFromPool()
    {
        for (int i = 0; i < arrowsPool.Length; i++)
        {
            if (!arrowsPool[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= attackCooldown)
            Attack();
    }

}
