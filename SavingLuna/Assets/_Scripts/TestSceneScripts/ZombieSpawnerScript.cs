using System.Collections;
using UnityEngine;

public class ZombieSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] zombiesToSpawn;
    private void Awake()
    {
        StartCoroutine(WaitToSpawn());
    }

    IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < zombiesToSpawn.Length; i++)
        {
            Instantiate(zombiesToSpawn[i], transform.position, Quaternion.identity, transform);
        }
    }
}
