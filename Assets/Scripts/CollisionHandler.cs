using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  
   [SerializeField] float invokeTime = 1f;
   [SerializeField] AudioClip success;
   [SerializeField] AudioClip crash;

    AudioSource audioSource;

    bool isTransitioning = false;


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
            Debug.Log("Friendly object was hit...");
            break;
        case "Finish":
            Debug.Log("Congrats you finished!");
            StartSuccessSequence("LoadNextLevel");
            break;
        default:
            Debug.Log("Sorry you blew up!");
            StartCrashSequence("ReloadLevel");
            break;
     }
   }

    void StartSuccessSequence(string methodAction)
    {   
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        // TODO add particaly effect 
        GetComponent<Movement>().enabled = false;
        Invoke(methodAction, invokeTime);
         

    }

    void StartCrashSequence(string methodAction)
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        // TODO add particaly effect 
        GetComponent<Movement>().enabled = false;
        Invoke(methodAction, invokeTime);
         
    }
 
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        isTransitioning = false;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
        SceneManager.LoadScene(nextSceneIndex);
        
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
