using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    // URL to the GitHub repository
    public string githubURL = "https://github.com/DenysRudenko/Rocket-Launcher-1.0-Unity";

    // Method called when the exit button is clicked
    public void ExitButton(){
        // Close the application
        Application.Quit();
        // Log a message indicating that the game is closed
        Debug.Log("Game Closed");
    }

    // Method called when the start game button is clicked
    public void StartGame() {
        // Load the scene with build index 1 (assuming it is the game scene)
        SceneManager.LoadScene(1);
    }

    // Method called when an image is clicked
    public void OnImageClick()
    {
        // Open the GitHub URL in a web browser
        Application.OpenURL(githubURL);
    }

    // Method called when the start menu button is clicked
    public void StartMenu() {
        // Load the scene with build index 0 (assuming it is the main menu scene)
        SceneManager.LoadScene(0);
    }
}

