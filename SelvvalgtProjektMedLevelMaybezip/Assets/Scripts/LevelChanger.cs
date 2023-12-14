using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    public RawImage fadeImage;
    public float fadeSpeed = 1.5f;

    private bool isFading = false;

    private void Start()
    {
        // Start the fade-out effect on the first scene
        StartCoroutine(FadeEffect(new Color(0.1176f, 0.1176f, 0.1176f, 1f), Color.clear));
    }

    private void Update()
    {
        // Check for the F key press
        if (Input.GetKeyDown(KeyCode.F) && !isFading)
        {
            // Change the scene name here to "Phase1"
            if (SceneManager.GetActiveScene().name != "Phase1")
            {
                // Start the fade-in effect when F is pressed
                StartCoroutine(FadeEffect(Color.clear, new Color(0.1176f, 0.1176f, 0.1176f, 1f)));
            }
            else
            {
                Debug.Log("Cannot change to the same scene.");
            }
        }
    }

    private System.Collections.IEnumerator FadeEffect(Color startColor, Color endColor)
    {
        isFading = true;

        float elapsedTime = 0f;

        while (elapsedTime < fadeSpeed)
        {
            if (fadeImage != null) // Null check
            {
                Color currentColor = Color.Lerp(startColor, endColor, elapsedTime / fadeSpeed);
                fadeImage.color = currentColor;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (fadeImage != null) // Null check
        {
            fadeImage.color = endColor;
        }

        if (endColor == Color.clear)
        {
            // Only transition if 'F' is pressed after fade-in is complete
            while (!Input.GetKeyDown(KeyCode.F))
            {
                yield return null;
            }

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

            SceneManager.LoadScene(nextSceneIndex);
        }

        isFading = false;
    }
}
