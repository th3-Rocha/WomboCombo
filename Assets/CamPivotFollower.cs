using UnityEngine;

public class CamPivotFollower : MonoBehaviour
{
    // The target pivot to follow
    public Transform targetPivot;

    // The speed of the movement
    public float moveSpeed = 5f;

    // The damping factor
    public float damping = 0.1f;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        if (targetPivot == null)
        {
            Debug.LogError("Target pivot not set.");
        }
    }

    void Update()
    {
        if (targetPivot != null)
        {
            // Smoothly move towards the target position using damping
            Vector3 targetPosition = targetPivot.position;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping, moveSpeed);
        }
    }
}
