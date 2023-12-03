using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private float cooldownTime = 5.0f;
    private float nextDamageTime = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost") && Time.time >= nextDamageTime)
        {
            PlayerHealth health = GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(1); 
                nextDamageTime = Time.time + cooldownTime; 
            }
        }
    }
}
