using UnityEngine;

public class AudioProximity : MonoBehaviour
{
    public Transform player;         // Reference to the player's transform
    public AudioSource audioSource;  // Reference to the AudioSource component
    public float maxVolume = 1f;     // Maximum volume when player is at the minimum distance
    public float minVolume = 0.1f;   // Minimum volume when player is at the maximum distance
    public float maxDistance = 10f;  // Maximum distance at which the audio is audible
    public float minDistance = 2f;   // Minimum distance at which the audio is audible

    void Start()
    {
        // Assign the main camera as the player if not specified
        if (player == null)
        {
            player = Camera.main.transform;
        }

        // Ensure there is an AudioSource component attached
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component not found on the GameObject.");
            }
        }
    }

    void Update()
    {
        // Calculate the distance between the player and the object
        float distance = Vector3.Distance(transform.position, player.position);

        // Adjust the volume based on distance
        float volume = Mathf.Lerp(minVolume, maxVolume, 1 - Mathf.Clamp01((distance - minDistance) / (maxDistance - minDistance)));

        // Set the audio source volume
        audioSource.volume = volume;
    }
}
