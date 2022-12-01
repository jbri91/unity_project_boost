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
     
     switch (other.gameObject.tag)
     {
        case "Friendly":
            Debug.Log("Friendly object was hit...");
            break;
        case "Finish":
            Debug.Log("Congrats you finished!");
            if (isTransitioning == false)
            {
                StartSuccessSequence("LoadNextLevel");
            }
            else
            {
                Debug.Log("Transitioning...");
            }
            break;
        default:
            Debug.Log("Sorry you blew up!");
            if (isTransitioning == false)
            {
                StartCrashSequence("ReloadLevel");
               
            }
            else 
            {
                Debug.Log("Transitioning");
            }
            break;
     }
   }

    void StartSuccessSequence(string methodAction)
    {
        audioSource.PlayOneShot(success);
        isTransitioning = true;
        // TODO add particaly effect 
        GetComponent<Movement>().enabled = false;
        Invoke(methodAction, invokeTime);
         

    }

    void StartCrashSequence(string methodAction)
    {
        audioSource.PlayOneShot(crash);
        isTransitioning = true;
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
