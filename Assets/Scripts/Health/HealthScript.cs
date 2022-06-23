using UnityEngine;

public class HealthScript : MonoBehaviour
{

    [SerializeField] private float startingHealth;
    [SerializeField] private StealthBarScript barScript;

    private Animator animator;
    private Player2DMovementScript playerMovement;
    private bool isDead = false;

    public float currentHealth { get; private set; }

    private void Awake()
    {
        playerMovement = GetComponent<Player2DMovementScript>();
        animator = GetComponent<Animator>();
        currentHealth = startingHealth;
        barScript.SetStealth(currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        barScript.SetStealth(currentHealth);
        if (currentHealth > 0)
            animator.SetBool("isHurt", true);
        else
        {
            if (!isDead)
            {
                isDead = true;
                animator.SetBool("isDead", isDead);
                playerMovement.enabled = false;
            }
        }
    }

    public void DisableHurtAnimation()
    {
        animator.SetBool("isHurt", false);
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
        barScript.SetStealth(currentHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }

}
