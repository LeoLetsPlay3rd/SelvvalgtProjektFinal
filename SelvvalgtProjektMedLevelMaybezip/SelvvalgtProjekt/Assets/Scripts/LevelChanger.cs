using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    public RawImage fadeImage;
    public float fadeSpeed = 1.5f;

    private bool isFading = false;
    private bool hasStartedFadeOut = false; // Flag to ensure fade-out happens only once

    private void Start()
    {
        if (!hasStartedFadeOut)
        {
            // Start the fade-out effect on the first scene
            StartCoroutine(FadeEffect(new Color(0.1176f, 0.1176f, 0.1176f, 1f), Color.clear));
            hasStartedFadeOut = true;
        }
    }

    private void Update()
    {
        // Check for the F key press
        if (Input.GetKeyDown(KeyCode.F) && !isFading)
        {
            if (SceneManager.GetActiveScene().name != "CharacterTest")
            {
                // Start the fade-in effect when F is pressed
                StartCoroutine(FadeEffect(Color.clear, new Color(0.1176f, 0.1176f, 0.1176f, 1f)));
            }
            else
            {
                Debug.Log("Cannot change scene from 'CharacterTest'.");
            }
        }
    }

    public void HandleLevelChange()
    {
        Vector3 startPosition = PlayerTransformInfo.Instance.GetStartPosition();
        Quaternion startRotation = PlayerTransformInfo.Instance.GetStartRotation();
        transform.position = startPosition;
        transform.rotation = startRotation;

        // Load the next scene or perform other actions
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        // Load the next scene in the build index when fade-out is complete
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);

        // Disable this script in the next scene
        SceneTransitionController.Instance.CanTransition = false;
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
