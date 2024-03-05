using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
       
        if (currentHealth <= 0)
        {
            Die();
        }
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
    }
    
    void Die()
    {

        GetComponent<Rigidbody2D>().simulated = false;
        animator.SetTrigger("Died");
        this.enabled = false;
    }


}
