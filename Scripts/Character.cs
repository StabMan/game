using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    new private Rigidbody2D rigidbody;
    private Animator animator;
    private bool isGrounded = false;

    public float maxHealth = 100;
    public float currentHealth;



    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }



    public void TakeDamage(float damage)
    {
        currentHealth -= damage;


        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("isDead");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
