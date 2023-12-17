using UnityEngine;

public class RocketMenu : MonoBehaviour
{   
    // Parameters
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainBoosterParticles;
    [SerializeField] ParticleSystem leftBoosterParticles;
    [SerializeField] ParticleSystem rightBoosterParticles;
    
    Rigidbody rb;
    AudioSource rocketSound;
    AudioSource backgroundMusic;

    private Animator anim;
    private bool isAnimationPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();

        rocketSound = GetComponent<AudioSource>();
        backgroundMusic = gameObject.AddComponent<AudioSource>();

        // Load and set the background music AudioClip
        backgroundMusic.clip = Resources.Load<AudioClip>("BackgroundMusic");

        // Start playing the background music on a loop
        backgroundMusic.loop = true;
        backgroundMusic.Play();

        if (mainBoosterParticles != null)
        {
            mainBoosterParticles.Play();
            leftBoosterParticles.Play();
            rightBoosterParticles.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method for rocket to fly up and sound for rocket
    
}

