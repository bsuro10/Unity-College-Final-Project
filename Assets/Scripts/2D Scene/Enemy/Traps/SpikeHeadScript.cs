using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadScript : EnemyDamageScript
{

    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] private float checkDelay;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform leftEdge;

    [Header("SFX")]
    [SerializeField] private AudioClip impactSound;

    private Vector3[] directions = new Vector3[4];
    private Vector3 destination;
    private float checkTimer;
    private bool isAttacking;

    private void OnEnable()
    {
        Stop();
    }

    private void Update()
    {
        if (isAttacking)
        {
            if ((Mathf.Sign(destination.x) > 0 && transform.position.x < rightEdge.position.x) ||
                (Mathf.Sign(destination.x) < 0 && transform.position.x > leftEdge.position.x))
                transform.Translate(destination * Time.deltaTime * speed);
            else
                isAttacking = false;
        }
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer();
        }
    }

    private void CheckForPlayer()
    {
        CalculateDirections();
        for (int i = 0; i < directions.Length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);
            if (hit.collider != null && !isAttacking)
            {
                isAttacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }

    private void CalculateDirections()
    {
        directions[0] = transform.right * range;
        directions[1] = -transform.right * range;
        directions[2] = transform.up * range;
        directions[3] = -transform.up * range;
    }

    private void OnDrawGizmos()
    {
        CalculateDirections();
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
        }
    }

    private void Stop()
    {
        destination = transform.position;
        isAttacking = false;
    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instace.PlaySound(impactSound);
        base.OnTriggerEnter2D(collision);
        Stop();
    }

}
