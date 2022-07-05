using UnityEngine;

public class HealthCollectibleScript : MonoBehaviour
{
    [SerializeField] private float healthValue;

    [Header("SFX")]
    [SerializeField] private AudioClip pickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.instace.PlaySound(pickUpSound);
            collision.GetComponent<HealthScript>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
