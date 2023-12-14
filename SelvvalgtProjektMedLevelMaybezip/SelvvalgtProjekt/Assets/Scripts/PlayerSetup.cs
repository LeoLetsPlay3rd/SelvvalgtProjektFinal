using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    private void Start()
    {
        // Set the initial player position
        PlayerTransformInfo.Instance.SetStartPosition(transform.position, transform.rotation);

        // Find LevelChanger and invoke a method to handle the level change
        LevelChanger levelChanger = FindObjectOfType<LevelChanger>();
        if (levelChanger != null)
        {
            levelChanger.HandleLevelChange();
        }
    }
}
