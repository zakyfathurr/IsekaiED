using UnityEngine;
using System.Collections.Generic;

public class EnemyStat : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;

    void Awake()
    {
        currentMoveSpeed = enemyData.moveSpeed;
        currentHealth = enemyData.maxHealth;
        currentDamage = enemyData.damage;
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStat character = collision.GetComponent<PlayerStat>();   
            character.TakeDamage(currentDamage);
        }
    }
}
