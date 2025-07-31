using UnityEngine;

public class CatLunaScript : MonoBehaviour
{
    [SerializeField] private GameObject palica;
    [SerializeField] private GameObject finalZombiesSpawner;
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
            PlayerMovement.playerHasCat = true;
            finalZombiesSpawner.SetActive(true);
            Destroy(palica);
            Destroy(gameObject);
        }
    }
}
