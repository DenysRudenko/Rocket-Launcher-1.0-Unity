using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinSuccess : MonoBehaviour
{   
    // UI element for displaying the coin count
    public TextMeshProUGUI coinText;

    // Static variable to track the total number of coins across scenes
    public static int coinsAmount;

    // Make the script persist across scenes
    private void Awake()
    {
        // Prevent this GameObject from being destroyed when loading new scenes
        DontDestroyOnLoad(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the UI text with the current coin count
        UpdateCoinText();
    }

    // Update is called once per frame
    void Update()
    {
        // This method is currently empty, as there are no frame-dependent updates
    }

    // Method to update the coin count and UI text when coins are added
    public void UpdateCoinsAmount()
    {   
        // Increase the coin count by 50 (or any desired amount)
        coinsAmount += 50;
        // Update the UI text to reflect the new coin count
        UpdateCoinText();
    }

    // Method to update the UI text with the current coin count
    void UpdateCoinText()
    {
        // Check if the coinText variable is assigned
        if (coinText != null)
        {
            // Update the text to display the current coin count
            coinText.text = coinsAmount.ToString();
        }
    }
}

