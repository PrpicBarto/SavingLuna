using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(IntroWait());
    }

    IEnumerator IntroWait()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(2);
    }
}
