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
    [SerializeField] private AudioSource audioSourceMainMenu;
    [SerializeField] private AudioSource audioSourceBackground;
    private void Awake()
    {
        DontDestroyOnLoad(audioSourceBackground.gameObject);
        DontDestroyOnLoad(audioSourceMainMenu.gameObject);
    }
    private void Start()
    {   
        audioSourceBackground.Stop();
        audioSourceMainMenu.Play();
    }
    private void Update()
    {
        audioSourceMainMenu.volume = volumeSlider.value;
        audioSourceBackground.volume = volumeSlider.value;
    }
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
