using UnityEngine;

public class PlayerTransformInfo : MonoBehaviour
{
    public static PlayerTransformInfo Instance;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Set the initial player position
    public void SetStartPosition(Vector3 position, Quaternion rotation)
    {
        startPosition = position;
        startRotation = rotation;
    }

    // Get the latest player position
    public Vector3 GetStartPosition()
    {
        return startPosition;
    }

    public Quaternion GetStartRotation()
    {
        return startRotation;
    }
}
