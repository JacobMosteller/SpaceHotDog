using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime;
    [SerializeField] AudioClip splatClip;
    [SerializeField] AudioClip successClip;
    [SerializeField] ParticleSystem splatParticals;
    [SerializeField] ParticleSystem successParticals;

    AudioSource audioSource;


    bool isTransitioning = false;

    void Start()   
    {
        audioSource = GetComponent<AudioSource>();
    }
    

    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning) { return; }

        string tag = other.gameObject.tag;
        switch(tag)
        {
            case "Friendly":
                Debug.Log("this item is friendly");
                break;
            case "Finish":
                BeginSuccess();
                break;
            default:
                BeginCrashSequence();
                break;
        }    
    }

    void BeginCrashSequence ()
    {
        GetComponent<Movement>().enabled = false;
        SplatEfects();
        Invoke("ReloadScene", delayTime);
    }
    void BeginSuccess ()
    {
        GetComponent<Movement>().enabled = false;
        SuccessEfects();
        Invoke("NextLevel", delayTime);
    }

    void SplatEfects()
    {
        splatParticals.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(splatClip);
        isTransitioning = true;

    }
    
    void SuccessEfects()
    {
        successParticals.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(successClip);
        isTransitioning = true;
    }

    void NextLevel()
    {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }
        SceneManager.LoadScene(nextLevelIndex);
    }
    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
