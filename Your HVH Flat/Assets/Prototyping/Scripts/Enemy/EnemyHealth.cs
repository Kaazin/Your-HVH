using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth, currentHealth;

    private bool isDead;

    void Awake()
    {
        currentHealth = maxHealth;

    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && !isDead)
            Die();
    }

    void Die()
    {
        isDead = true;
        Destroy(this.transform.gameObject);
    }
}
