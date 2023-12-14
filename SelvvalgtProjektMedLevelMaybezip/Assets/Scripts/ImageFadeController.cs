using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadeController : MonoBehaviour
{
    public float fadeDuration = 2f;
    public Image imageToFade;
    public Canvas canvasToDisable;

    private void Start()
    {
        // Start the fade-out process after a short delay
        StartCoroutine(FadeOutImage());
    }

    private IEnumerator FadeOutImage()
    {
        float elapsedTime = 0f;
        Color startColor = imageToFade.color;

        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            Color currentColor = Color.Lerp(startColor, Color.clear, t);
            SetImageColor(currentColor);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        SetImageColor(Color.clear);

        // Disable the canvas after the image fades away
        DisableCanvas();
    }

    private void SetImageColor(Color color)
    {
        if (imageToFade != null)
        {
            imageToFade.color = color;
        }
    }

    private void DisableCanvas()
    {
        if (canvasToDisable != null)
        {
            canvasToDisable.enabled = false;
        }
    }
}
