using UnityEngine;

public class AudioLose : MonoBehaviour
{
    [SerializeField] private AudioSource audioMainMenu;
    [SerializeField] private AudioSource audioBackground;
    private void Awake()
    {
        audioMainMenu = GameObject.Find("MainMenuMusic").GetComponent<AudioSource>();
        audioBackground = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioBackground.Stop();
        audioMainMenu.Play();
    }
}
