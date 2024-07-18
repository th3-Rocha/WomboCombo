using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Transform target; // The target position to move the ragdoll to
    public float moveSpeed = 5f; // Speed at which the ragdoll moves
    public float damping = 1f; // Damping to smooth out the movement

    private Rigidbody[] rigidbodies;

    void Start()
    {
        // Get all Rigidbody components in the ragdoll
        rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    void FixedUpdate()
    {
        MoveRagdoll();
    }

    void MoveRagdoll()
    {
        foreach (var rb in rigidbodies)
        {
            if (rb == null) continue;

            // Calculate direction to target
            Vector3 direction = (target.position - rb.transform.position).normalized;

            // Apply force to the rigidbody to move it towards the target
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, direction * moveSpeed, Time.fixedDeltaTime * damping);
        }
    }
}
