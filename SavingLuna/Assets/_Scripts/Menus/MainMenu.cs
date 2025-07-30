using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private TMP_Text volumeText;
    [SerializeField] private Slider volumeSlider;
    public void OnClickStart()
    {
        Debug.Log("START GAME");
        SceneManager.LoadScene(2);
    }
    public void OnClickQuit()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }

    public void OnClickOptionsOpen()
    {
        Debug.Log("OPEN OPTIONS");
        optionsPanel.SetActive(true);
        gamePanel.SetActive(false);
    }
    public void OnClickOptionsQuit()
    {
        Debug.Log("OPEN OPTIONS");
        gamePanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void OnSliderChanger()
    {
        volumeText.text = $"Volume: {(int)(volumeSlider.value * 100)}%";
    }



}
