using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickStart()
    {
        Debug.Log("START GAME");
        SceneManager.LoadScene(1);
    }
    public void OnClickQuit()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }

}
