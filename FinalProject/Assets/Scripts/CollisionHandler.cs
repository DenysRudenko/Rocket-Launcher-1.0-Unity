using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CollisionHandler : MonoBehaviour
{   
    [SerializeField] float levelLoadDeley = 2f;
    [SerializeField] float objectDestroyDeley = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    public Health healthScript;
    public Fuel fuelScript;
    public CoinSuccess coinScript;
    AudioSource audioSource;
    bool isTransitioning = false;
    bool collisionDisabled = false;
    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    void Update() 
    {
        RespondToDebugKeys();
    }

    // Cheat code method to load next level pressing L button
    // and pressing C button to turn off collision = GodMode
    void RespondToDebugKeys()
    {   

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled; // toggle collison
        }
    }

  void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || collisionDisabled)
        {
            return;
        }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
           case "Finish":
                StartSuccessSequence();
                coinScript.UpdateCoinsAmount();
                break;
            case "Fuel":
                Debug.Log("This thing is fuel");
                break;
            default:
                HeartLoss();
                FuelLoss();
                break;
        }
    }

    void HeartLoss(){
        
        if (healthScript != null)
        {   
            healthScript.TakeDamage(1);

            if(healthScript.maxHealth == 0) 
            {
                StartCrashSequence();
            }            
        }
    }

    void FuelLoss(){
        
        if (fuelScript != null)
    {
        if (fuelScript.fuel <= 0)
        {
            StartCrashSequence();
        }
    }
}

    void StartCrashSequence()
    {   
        isTransitioning = true;
        audioSource.Stop();
        crashParticles.Play();
        audioSource.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDeley);
    }

    // created a deley method for next level loading
    void StartSuccessSequence()
    {   
        isTransitioning = true;
        audioSource.Stop();
        successParticles.Play();
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDeley);
    }

    void ReloadLevel()
    {   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex ;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex ;
        int nextSceneIndex = currentSceneIndex + 1;
        

        // restart the scene to the begining
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {   
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

     void DisableGameObject()
    {
        // Disable the GameObject  
        gameObject.SetActive(false);

    }
}
