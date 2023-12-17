using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    // Current fuel level
    public float fuel = 100;
    
    // Maximum fuel capacity
    public float maxFuel = 100;

    // UI element representing the fuel bar
    public Image fuelBar;

    // Array of UI elements representing individual fuel points
    public Image[] fuelPoints;

    // Rate at which fuel decreases when the space bar is pressed
    float damageRate = 25f;

    // Start is called before the first frame update
    private void Start()
    {
        // Initialization code can be placed here if needed
    }

    // Update is called once per frame
    private void Update()
    {
        // Update the fuel bar UI and color
        fuelBarFilter();

        // Ensure that fuel doesn't exceed the maximum capacity
        if (fuel > maxFuel)
        {
            fuel = maxFuel;
        }

        // Decrease fuel when the 'Space' key is pressed
        if (Input.GetKey(KeyCode.Space))
        {
            DecreaseFuel(damageRate * Time.deltaTime);
        }

        // Update the color of the fuel bar
        ColorChanger();
    }

    // Update the fuel bar UI elements
    void fuelBarFilter()
    {
        // Smoothly interpolate the fill amount of the fuel bar
        fuelBar.fillAmount = Mathf.Lerp(fuelBar.fillAmount, fuel / maxFuel, damageRate);

        // Toggle visibility of individual fuel points based on current fuel level
        for (int i = 0; i < fuelPoints.Length; i++)
        {
            fuelPoints[i].enabled = !DisplayFuelPoints(fuel, i);
        }
    }

    // Determine whether to display or hide a specific fuel point
    bool DisplayFuelPoints(float _health, int pointNumber)
    {
        // Compare the fuel level to the point number (each point represents 10 units)
        return ((pointNumber * 10) >= _health);
    }

    // Update the color of the fuel bar based on the current fuel level
    void ColorChanger()
    {
        // Interpolate between red and green based on the fuel percentage
        Color fuelColor = Color.Lerp(Color.red, Color.green, (fuel / maxFuel));

        // Apply the calculated color to the fuel bar
        fuelBar.color = fuelColor;
    }

    // Decrease the fuel level by a specified amount
    public void DecreaseFuel(float decreaseAmount)
    {
        // Ensure that fuel doesn't go below zero
        if (fuel > 0)
        {
            fuel -= decreaseAmount;
        }
    }

    // Increase the fuel level by a specified amount (healing)
    public void Heal(float healingPoints)
    {
        // Ensure that fuel doesn't exceed the maximum capacity
        if (fuel < maxFuel)
        {
            fuel += healingPoints;
        }
    }
}
