using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthBar;

    private float timeBetweenDamage = 5f;
    private float timer = 0f;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void Update()
    {
        if (timer >= timeBetweenDamage)
        {
            // No need to decrease health here anymore
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void TakeDamage()
    {
        // Decrease health when called by enemyAttack script
        currentHealth -= 1; // Adjust as needed
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update health bar
        UpdateHealthBar();

        // Check if the player is dead
        if (currentHealth <= 0)
        {
            // Handle player death (e.g., game over)
            SceneManager.LoadScene("Menu");

        }
    }

    private void UpdateHealthBar()
    {
        // Update the health bar UI
        healthBar.value = (float)currentHealth / maxHealth;
    }
}
