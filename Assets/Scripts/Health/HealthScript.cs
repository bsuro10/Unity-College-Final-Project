using System.Collections;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    [Header("Health")]
    [SerializeField] private float startingHealth;
    [SerializeField] private StealthBarScript barScript;

    [Header("iFrame")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlahses;
    [SerializeField] private string playerLayerName;
    [SerializeField] private string enemyLayerName;

    private Animator animator;
    private Player2DMovementScript playerMovement;
    private SpriteRenderer spriteRenderer;
    private bool isDead = false;

    public float currentHealth { get; private set; }

    private void Awake()
    {
        playerMovement = GetComponent<Player2DMovementScript>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = startingHealth;
        barScript.SetStealth(currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        barScript.SetStealth(currentHealth);
        if (currentHealth > 0)
        {
            StartCoroutine(Invulnerability());
            animator.SetBool("isHurt", true);
        }
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

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(playerLayerName), LayerMask.NameToLayer(enemyLayerName), true);
        for (int i = 0; i < numberOfFlahses; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlahses * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlahses * 2));
        }
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(playerLayerName), LayerMask.NameToLayer(enemyLayerName), false);
    }
}
