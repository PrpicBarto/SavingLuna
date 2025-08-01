using UnityEngine;

public class AudioGame : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceMainMenu;
    [SerializeField] private AudioSource audioSourceBackground;
    private void Awake()
    {
        audioSourceMainMenu = GameObject.Find("MainMenuMusic").GetComponent<AudioSource>();
        audioSourceBackground = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSourceMainMenu.Stop();
        audioSourceBackground.Play();
    }
}
