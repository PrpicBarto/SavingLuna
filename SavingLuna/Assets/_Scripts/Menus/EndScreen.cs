using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void RestartButton()
    {
        Debug.Log("Restarting the game...");
        SceneManager.LoadScene(1);
    }
    public void BackToMainMenu()
    {
        Debug.Log("Returning to main menu...");
        SceneManager.LoadScene(0);
    }
   
}
