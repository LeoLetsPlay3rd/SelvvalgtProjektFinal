using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SecondSceneController : MonoBehaviour
{
    public Color fadeColor = new Color(0.1176f, 0.1176f, 0.1176f, 1f);
    public float fadeDuration = 2f;
    public Image imageToFade;
    public TMP_Text textToFade;
    public float imageFadeDuration = 10f;
    public float textFadeInDuration = 1f;
    public float textDisplayDuration = 3f;
    public float textFadeOutDuration = 1f;

    private void Start()
    {
        StartCoroutine(FadeInImage());
    }

    private IEnumerator FadeInImage()
    {
        float elapsedTime = 0f;
        Color startColor = new Color(1f, 1f, 1f, 1f);

        while (elapsedTime < imageFadeDuration)
        {
            float t = elapsedTime / imageFadeDuration;
            Color currentColor = Color.Lerp(startColor, Color.clear, t);
            SetImageColor(currentColor);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        SetImageColor(Color.clear);

        yield return new WaitForSeconds(textFadeInDuration);

        StartCoroutine(FadeInText());

        yield return new WaitForSeconds(textDisplayDuration);

        StartCoroutine(FadeOutText());
    }

    private IEnumerator FadeInText()
    {
        float elapsedTime = 0f;
        Color startColor = textToFade.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (elapsedTime < textFadeInDuration)
        {
            float t = elapsedTime / textFadeInDuration;
            Color currentColor = Color.Lerp(startColor, targetColor, t);
            textToFade.color = currentColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        textToFade.color = targetColor;
    }

    private IEnumerator FadeOutText()
    {
        float elapsedTime = 0f;
        Color startColor = textToFade.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < textFadeOutDuration)
        {
            float t = elapsedTime / textFadeOutDuration;
            Color currentColor = Color.Lerp(startColor, targetColor, t);
            textToFade.color = currentColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        textToFade.color = targetColor;

        // Load the next scene
        LoadNextScene();
    }

    private void SetImageColor(Color color)
    {
        imageToFade.color = color;
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
