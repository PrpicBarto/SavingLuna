using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void OnClickRestart()
    {
        SceneManager.LoadScene(2); // Assuming scene index 2 is the game scene
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0); // Assuming scene index 0 is the main menu
    }
}
