using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of the character movement
    public float rotationSpeed = 720f;  // Speed of character rotation

    private void Update()
    {
        // Get the input for movement (W, A, S, D or Arrow Keys)
        float horizontal = Input.GetAxis("Horizontal");  // Left/Right input (A/D or Arrow Left/Right)
        float vertical = Input.GetAxis("Vertical");      // Forward/Backward input (W/S or Arrow Up/Down)

        // Calculate the movement direction based on input
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Move the character
        if (direction.magnitude >= 0.1f)
        {
            // Calculate the target angle for rotation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // Smoothly rotate the character to face the movement direction
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Move the character forward in the direction they are facing
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}

