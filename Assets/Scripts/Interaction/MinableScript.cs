using UnityEngine;

public class MinableScript : CollectableScript
{
    public float maxHealth;
    public float currentHealth;
    public StealthBarScript barScript;
    public SoundsManagerScript soundsManagerScript;
    public AudioClip mineSound;

    private void Start()
    {
        currentHealth = maxHealth;
        barScript.SetMaxStealth(maxHealth);
    }

    protected override void Collect()
    {
        soundsManagerScript.PlaySound(mineSound);
        currentHealth -= SceneManagerScript.Instance.playerScript.attackDamage;
        barScript.SetStealth(currentHealth);
        if (currentHealth <= 0)
            base.Collect();
    }

}
