using UnityEngine;

public class SceneTransitionController : MonoBehaviour
{
    private static SceneTransitionController instance;

    public static SceneTransitionController Instance
    {
        get
        {
            if (instance == null)
            {
                // Use AddComponent to create an instance of SceneTransitionController
                instance = new GameObject("SceneTransitionController").AddComponent<SceneTransitionController>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    public bool CanTransition { get; set; } = true;
}
