using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public Transform target;  // Assign your player (e.g., Ghost1 or LightBandit)
    public float fixedY = 12.2f; // Matches your initial Y position

    void Start()
    {
        // Auto-find target if not assigned and tagged as "Kuker"
        if (target == null)
        {
            GameObject kuker = GameObject.FindGameObjectWithTag("Kuker");
            if (kuker != null) target = kuker.transform;
            else Debug.LogWarning("No target assigned and 'Kuker' tag not found!");
        }

        // Set the initial position of the camera
        transform.position = new Vector3(0, fixedY, transform.position.z);
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Update X and Z positions while keeping Y fixed
            transform.position = new Vector3(
                target.position.x,
                fixedY,
                target.position.z - 14.4f
            );
        }
    }
}
