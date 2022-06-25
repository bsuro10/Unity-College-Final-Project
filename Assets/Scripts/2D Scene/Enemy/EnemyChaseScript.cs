using UnityEngine;

public class EnemyChaseScript : MonoBehaviour
{

    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    [SerializeField] private float stoppingDistance;
    private MeleeEnemyScript meleeEnemy;
    private Vector3 initScale;
    private Animator animator;
    private bool isWalking = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        meleeEnemy = GetComponent<MeleeEnemyScript>();
        initScale = transform.localScale;
    }

    private void Update()
    {
        if (meleeEnemy.isAttacking)
            isWalking = false;
        else
        {
            if (target != null)
                ChaseTarget();
        }

        animator.SetBool("isWalking", isWalking);
    }

    private void ChaseTarget()
    {
        float moveDirection = Mathf.Sign((target.position - transform.position).x);
        if (Mathf.Abs(target.position.x - transform.position.x) > stoppingDistance)
        {
            if ((moveDirection > 0 && transform.position.x < rightEdge.position.x) ||
                (moveDirection < 0 && transform.position.x > leftEdge.position.x))
            {
                isWalking = true;
                transform.localScale = new Vector3(Mathf.Abs(initScale.x) * moveDirection, initScale.y, initScale.z);
                transform.position = new Vector3(transform.position.x + moveDirection * speed * Time.deltaTime, transform.position.y, transform.position.x);
            }
            else
                isWalking = false;
        }
        else
            isWalking = false;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

}
