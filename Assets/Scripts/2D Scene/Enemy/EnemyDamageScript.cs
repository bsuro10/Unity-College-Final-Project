using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyDamageScript : MonoBehaviour
{

    [SerializeField] protected float damage;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<HealthScript>().TakeDamage(damage);
    }

}
