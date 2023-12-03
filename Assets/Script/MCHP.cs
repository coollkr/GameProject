using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private Vector3 respawnPosition = new Vector3(-59.49f, 4.16f, -5.75f); 

    private Collider playerCollider;

    void Start()
    {
        currentHealth = maxHealth;
        playerCollider = GetComponent<Collider>(); 
        Debug.Log("Initial Health: " + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Damaged! Current Health: " + currentHealth);

        HealthEffectController healthEffectController = FindObjectOfType<HealthEffectController>();
        if (healthEffectController != null)
        {
            healthEffectController.TriggerHealthEffect();
        }

        if (currentHealth <= 0)
        {
            Respawn();
        }
    }


    private void Respawn()
    {
        if (playerCollider != null)
        {
            playerCollider.enabled = false; 
        }

        transform.position = respawnPosition; 
        currentHealth = maxHealth;
        
        if (playerCollider != null)
        {
            playerCollider.enabled = true; 
        }

        Debug.Log("Respawned at " + respawnPosition + ". Health reset to: " + currentHealth);
    }
}
