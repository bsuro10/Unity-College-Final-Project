using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScannerScript : MonoBehaviour
{

    public Transform scannerSourceTransform;
    public float maxAngle = 15f;
    public float minAngle = -15f;
    public float stealthDamage = 10f;
    public float stealthRate = 1f;
    public float attackRange = 8f;
    public float warningRange = 8f;

    private Vector3 m_rotateDirection;
    private float m_timeToAttack;
    private bool m_scanRight = true;

    void Start()
    {
        m_rotateDirection = scannerSourceTransform.up;
    }

    void Update()
    {
        ShootRayToScan();
    }

    void ShootRayToScan()
    {
        RotateScanner();
        RayCastAttack();
    }

    void RotateScanner()
    {
        scannerSourceTransform.RotateAround(scannerSourceTransform.position, m_rotateDirection, 25 * Time.deltaTime);
        if (m_scanRight && scannerSourceTransform.localRotation.y > Quaternion.Euler(0, maxAngle, 0).y)
        {
            m_scanRight = false;
            m_rotateDirection = -scannerSourceTransform.up;
        }
        if (!m_scanRight && scannerSourceTransform.localRotation.y < Quaternion.Euler(0, minAngle, 0).y)
        {
            m_scanRight = true;
            m_rotateDirection = scannerSourceTransform.up;
        }

    }

    void RayCastAttack()
    {
        InitRayCast(new Vector3(0, -0.5f, 0), attackRange, RayCastAttackCallback, Color.yellow);
        InitRayCast(new Vector3(0, -0.4f, 0), attackRange, RayCastAttackCallback, Color.yellow);
        InitRayCast(new Vector3(0, -0.3f, 0), attackRange, RayCastAttackCallback, Color.yellow);
        InitRayCast(new Vector3(0, -0.2f, 0), attackRange, RayCastAttackCallback, Color.yellow);
        InitRayCast(new Vector3(0, -0.1f, 0), attackRange, RayCastAttackCallback, Color.yellow);
        InitRayCast(Vector3.zero, attackRange, RayCastAttackCallback, Color.yellow);
        InitRayCast(new Vector3(0, 0.1f, 0), attackRange,RayCastAttackCallback, Color.yellow);
        InitRayCast(new Vector3(0, 0.2f, 0), attackRange, RayCastAttackCallback, Color.yellow);
        InitRayCast(new Vector3(0, 0.3f, 0), attackRange, RayCastAttackCallback, Color.yellow);
        InitRayCast(new Vector3(0, 0.4f, 0), attackRange, RayCastAttackCallback, Color.yellow);
        InitRayCast(new Vector3(0, 0.5f, 0), attackRange, RayCastAttackCallback, Color.yellow);
    }

    void RayCastAttackCallback(RaycastHit hit)
    {
        if (hit.collider.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(WarnPlayer());
            ScanPlayer();
        }
    }

    void InitRayCast(Vector3 offset, float range, Action<RaycastHit> callbackAction, Color color)
    {
        RaycastHit hit;
        Debug.DrawRay(scannerSourceTransform.position, (scannerSourceTransform.forward + offset) * range, color);
        if(Physics.Raycast(scannerSourceTransform.position, scannerSourceTransform.forward + offset, out hit, range))
        {
            callbackAction.Invoke(hit);
        }
    }

    void ScanPlayer()
    {
        if (Time.time >= m_timeToAttack)
        {
            m_timeToAttack = Time.time + 1 / stealthRate;
            float distance = Vector3.Distance(SceneManagerScript.Instance.playerScript.transform.position, transform.position);
            SceneManagerScript.Instance.playerScript.TakeStealthDamage(stealthDamage * (1 / distance));
        }
    }

    IEnumerator WarnPlayer()
    {
        SceneManagerScript.Instance.playerScript.WarnPlayer();
        yield return new WaitForSeconds(3);
        SceneManagerScript.Instance.playerScript.ClearWarnPlayer();
    }

}
