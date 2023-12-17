using UnityEngine;

public class Movement : MonoBehaviour
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
    public Fuel fuelScript;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (fuelScript != null && fuelScript.fuel > 0)
        {
            ProcessThrust();
            ProcessRotation();
        }
    }

    // Method for rocket to fly up and sound for rocket
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {   
           isAnimationPlaying = !isAnimationPlaying;
           StartThrusting();
        }
        else
        {   
            StopThrusting();
        }
    }

    // Method for rocket to rotate left and right
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
           RotateLeft();
           
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else 
        {
           StopRotating();
        }
    }

    void StartThrusting()
    {
        if (fuelScript != null && fuelScript.fuel > 0)
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!rocketSound.isPlaying)
        {
            rocketSound.PlayOneShot(mainEngine);
        }
        if (!mainBoosterParticles.isPlaying)
        {
            mainBoosterParticles.Play();
        }
    }
    }

     void StopThrusting()
    {
        rocketSound.Stop();
        mainBoosterParticles.Stop();
    }

    void RotateLeft()
    {
         ApplyRotation(rotationThrust);
            if (!rightBoosterParticles.isPlaying)
            {
                rightBoosterParticles.Play();
            }
    }

    void RotateRight()
    {
        ApplyRotation(-rotationThrust);
            if (!leftBoosterParticles.isPlaying)
            {
                leftBoosterParticles.Play();
            }
    }

    void StopRotating()
    {
        rightBoosterParticles.Stop();
        leftBoosterParticles.Stop();
    }

    // Method for rotation than ProcessRotation is using for turning our rocket
    public void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;   // freezing rotating so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;  // unfreezing rotation so the physics system can take over
    }
}
