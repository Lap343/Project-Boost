using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;
    bool isTransitioning = false;
    bool isCollisionOn = false;

    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip CrashExplosion;
    [SerializeField] AudioClip SucessChime;
    
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem sucessParticles;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKey(KeyCode.C))
        {
            isCollisionOn = !isCollisionOn;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || isCollisionOn) { return; }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Well excuuuuuse me princess!");
                break;
            case "Finish":
                StartNextLevelSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(CrashExplosion);
        crashParticles.Play();
        Invoke("ReloadLevel", delayTime);
    }

    void StartNextLevelSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(SucessChime);
        sucessParticles.Play();
        Invoke("LoadNextLevel", delayTime);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}