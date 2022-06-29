using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class HealthScript : MonoBehaviour
{

    [Header("Health")]
    [SerializeField] private float startingHealth;
    [SerializeField] public float currentHealth;
    /*public float currentHealth { get; private set; }*/

    [Header("iFrame")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlahses;
    [SerializeField] private string playerLayerName = "Player";
    [SerializeField] private string enemyLayerName = "Enemy";

    [Header("On Death Action")]
    [SerializeField] private UnityEvent onDeathAction = new UnityEvent();

    [Header("Component")]
    [SerializeField] private Behaviour[] components;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isDead = false;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            animator.SetBool("isHurt", true);
            StartCoroutine(Invulnerability());
            SoundManager.instace.PlaySound(hurtSound);
        }
        else
        {
            if (!isDead)
            {
                isDead = true;
                animator.SetBool("isDead", isDead);

                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                SoundManager.instace.PlaySound(deathSound);
                onDeathAction.Invoke();
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
