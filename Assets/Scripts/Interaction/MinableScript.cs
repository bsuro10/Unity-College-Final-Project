using UnityEngine;

public class MinableScript : CollectableScript
{
    public float maxHealth;
    public float currentHealth;
    public StealthBarScript barScript;

    private void Start()
    {
        currentHealth = maxHealth;
        barScript.SetMaxStealth(maxHealth);
    }

    protected override void Collect()
    {
        currentHealth -= SceneManagerScript.Instance.playerScript.attackDamage;
        barScript.SetStealth(currentHealth);
        if (currentHealth <= 0)
            base.Collect();
    }

}
