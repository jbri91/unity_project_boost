using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  
   [SerializeField] float invokeTime = 1f;

   void OnCollisionEnter(Collision other) 
   {
     
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
        //  TODO add SFX upon landing
        // TODO add particaly effect 
        GetComponent<Movement>().enabled = false;
        Invoke(methodAction, invokeTime);
         

    }

    void StartCrashSequence(string methodAction)
    {
        //  TODO add SFX upon crash
        // TODO add particaly effect 
        GetComponent<Movement>().enabled = false;
        Invoke(methodAction, invokeTime);
         
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
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
