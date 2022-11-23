using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  

   void OnCollisionEnter(Collision other) 
   {
     
     switch (other.gameObject.tag)
     {
        case "Friendly":
            Debug.Log("Friendly object was hit...");
            break;
        case "Fuel":
            Debug.Log("Fuel object was hit...");
            break;
        case "Finish":
            Debug.Log("Congrats you finished!");
            LoadNextLevel();
            break;
        default:
            Debug.Log("Sorry you blew up!");
            ReloadLevel();
            break;
     }
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
