using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;
    bool isTransitioning = false;

    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip DeathExplosion;
    [SerializeField] AudioClip SucessChime;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning) { return; }

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
        audioSource.PlayOneShot(DeathExplosion);
        Invoke("ReloadLevel", delayTime);
    }

    void StartNextLevelSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(SucessChime);
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