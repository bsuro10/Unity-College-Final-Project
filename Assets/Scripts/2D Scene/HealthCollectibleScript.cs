using UnityEngine;

public class HealthCollectibleScript : MonoBehaviour
{
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthScript>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
