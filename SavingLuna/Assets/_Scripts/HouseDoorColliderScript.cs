using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDoorColliderScript : MonoBehaviour
{
    [SerializeField] private GameObject subtitlesContrastPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement PlayerMovement))
        {
            if (PlayerMovement.playerHasCat == true)
            {
                SceneManager.LoadScene(4);
            }
            else
            {
                subtitlesContrastPanel.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement PlayerMovement))
        {
            subtitlesContrastPanel.SetActive(false);
        }
    }
}
