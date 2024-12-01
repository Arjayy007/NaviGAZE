using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
   public void LoadScene(string sceneName)
   {
         UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
 
   }
}
