using UnityEngine;

public class CatLunaScriptTest : MonoBehaviour
{
    [SerializeField] private GameObject finalZombiesSpawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finalZombiesSpawner.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
//        finalZombiesSpawner.SetActive(true);
    }
}
