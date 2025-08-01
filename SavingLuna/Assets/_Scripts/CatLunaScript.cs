using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CatLunaScript : MonoBehaviour
{
    [SerializeField] private GameObject palica;
    [SerializeField] private GameObject luna;
    [SerializeField] private GameObject finalZombiesSpawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            playerMovement.playerHasCat = true;
            finalZombiesSpawner.SetActive(true);
            palica.SetActive(false);
            luna.SetActive(true);
            Destroy(gameObject);
        }
    }

}
