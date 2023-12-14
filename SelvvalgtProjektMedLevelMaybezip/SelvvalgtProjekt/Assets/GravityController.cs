using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float gravityStrength = 9.8f;
    public Transform player; // Reference to the player's Transform

    void FixedUpdate()
    {
        FollowPlayer();
        ApplyGravity();
    }

    void FollowPlayer()
    {
        if (player != null)
        {
            // Adjust the gravity controller's position to match the player's position
            transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
        }
    }

    void ApplyGravity()
    {
        Rigidbody[] characterRigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in characterRigidbodies)
        {
            // Apply gravity only along the y-axis to avoid unwanted horizontal forces
            Vector3 gravityDirection = Vector3.down;
            rb.AddForce(gravityDirection * gravityStrength);

            // Limit the velocity to prevent excessive speeds
            Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
        }
    }
}
