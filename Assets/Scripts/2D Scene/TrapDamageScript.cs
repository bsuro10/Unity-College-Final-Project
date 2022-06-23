using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TrapDamageScript : MonoBehaviour
{

    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<HealthScript>().TakeDamage(damage);
    }
}
