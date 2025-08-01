using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScene : MonoBehaviour
{

    [SerializeField] GameObject[] panels;
    [SerializeField] TMP_Text[] textFields;
    private void Start()
    {
        StartCoroutine(IntroWait());
    }

    IEnumerator IntroWait()
    {
        
        foreach(GameObject panel in panels)
        {
            panel.SetActive(true);
            Image image = panel.GetComponent<Image>();
            yield return new WaitForSeconds(1f);
            Color startColor = image.color;
            Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
            float counter = 5f;
            while (counter > 0f)
            {
                counter -= Time.deltaTime;
                image.color = Color.Lerp(startColor, targetColor, 1 - (counter / 5f));
                yield return null;
            }
            yield return new WaitForSeconds(2f);
            TMP_Text text = panel.GetComponentInChildren<TMP_Text>();
            yield return new WaitForSeconds(1f); // Text stays visible for 1 second

            float counterText = 5f;
            while (counterText > 0f)
            {
                counterText -= Time.deltaTime;
                Color startTextColor = text.color;
                Color targetTextColor = new Color(startTextColor.r, startTextColor.g, startTextColor.b, 0f);
                text.color = new Color(
                    startTextColor.r,
                    startTextColor.g,
                    startTextColor.b,
                    Mathf.Lerp(startTextColor.a, targetTextColor.a, 1 - (counterText / 5f))
                );
                yield return null;
            }

            panel.SetActive(false);
        }
        SceneManager.LoadScene(2);
    }
}
