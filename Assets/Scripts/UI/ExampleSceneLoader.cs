

using UnityEngine;
using UnityEngine.SceneManagement;



public class ExampleSceneLoader : MonoBehaviour
{

    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.R))
        {
            LoadScene("MenuScene");
            UnLoadScene("UIEndScene");
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            LoadScene("MenuScene");
            UnLoadScene("UIScene");
        }
       

    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void UnLoadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

}




