using UnityEngine;

public class HealthScript : MonoBehaviour
{

    [SerializeField] private float startingHealth;
    [SerializeField] private StealthBarScript barScript;

    private Animator animator;

    public float currentHealth { get; private set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentHealth = startingHealth;
        barScript.SetStealth(currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        barScript.SetStealth(currentHealth);
        if (currentHealth > 0)
            animator.SetTrigger("hurt");
        else
            animator.SetTrigger("die");
    }

}
