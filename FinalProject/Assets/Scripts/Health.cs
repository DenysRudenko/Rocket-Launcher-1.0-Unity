using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Maximum health the player can have
    public int maxHealth = 3;

    // Number of hearts displayed on the UI
    public int numOfHearts = 3;

    // UI elements representing individual hearts
    public Image[] hearts;

    // Sprite for a full heart
    public Sprite fullHeart;

    // Sprite for an empty heart
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code can be placed here if needed
    }

    // Method called when the player takes damage
    public void TakeDamage(int damageAmount)
    {   
        // Decrease the player's health by the specified damage amount
        maxHealth -= damageAmount;

        // Ensure health doesn't go below 0
        maxHealth = Mathf.Max(0, maxHealth);

        // Update the hearts on the UI
        UpdateHearts();
    }

    // Method to update the hearts on the UI
    void UpdateHearts()
    {
        // Check if the hearts array is assigned
        if (hearts != null)
        {
            // Ensure maxHealth doesn't exceed the total number of hearts
            ClampMaxHealth();

            // Update the sprites of individual hearts
            UpdateHeartSprites();

            // Display or hide hearts based on the current health
            DisplayHearts();
        }
    }

    // Ensure maxHealth doesn't exceed the total number of hearts
    void ClampMaxHealth()
    {
        maxHealth = Mathf.Min(maxHealth, numOfHearts);
    }

    // Update the sprites of individual hearts based on the current health
    void UpdateHeartSprites()
    {   
        // Replace fullHeart with emptyHeart based on the current health
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < maxHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    // Display or hide hearts based on the total number of hearts
    void DisplayHearts()
    {   
        // Display hearts up to numOfHearts and disable the rest
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < numOfHearts;
        }
    }
}
