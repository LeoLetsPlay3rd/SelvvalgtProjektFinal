using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTrigger : MonoBehaviour
{
    public GameObject quad; // Assign the quad in the Inspector

    private void Start()
    {
        // Disable the quad renderer initially
        if (quad != null)
        {
            Renderer quadRenderer = quad.GetComponent<Renderer>();
            if (quadRenderer != null)
            {
                quadRenderer.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone.");

            // Enable the quad renderer
            if (quad != null)
            {
                Renderer quadRenderer = quad.GetComponent<Renderer>();
                if (quadRenderer != null)
                {
                    quadRenderer.enabled = true;
                }
            }

            // Switch scenes after a short delay
            Invoke("SwitchScene", 1f);
        }
    }

    private void SwitchScene()
    {
        // Load the next scene in the build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
