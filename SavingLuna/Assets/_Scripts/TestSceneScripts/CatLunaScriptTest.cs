using UnityEngine;

public class CatLunaScriptTest : MonoBehaviour
{
    [SerializeField] private GameObject finalZombiesSpawner;
    private void OnTriggerEnter(Collider other)
    {
        finalZombiesSpawner.SetActive(true);
    }
}
