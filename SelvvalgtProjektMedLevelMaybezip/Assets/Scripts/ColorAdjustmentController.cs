using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorAdjustmentController : MonoBehaviour
{
    public DualCanvasFader canvasFader;

    private void Start()
    {
        if (canvasFader == null)
        {
            Debug.LogError("DualCanvasFader reference not set. Assign the script to an object with DualCanvasFader in the inspector.");
            enabled = false; // Disable the script if DualCanvasFader reference is not set
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Check if Canvas 2 is currently active (faded in)
            if (canvasFader.IsCanvas2Active())
            {
                // Switch to the next scene in the build index
                LoadNextScene();
            }
        }
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
