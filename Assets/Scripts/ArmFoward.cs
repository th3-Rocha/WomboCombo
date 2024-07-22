using UnityEngine;

public class ArmForward : MonoBehaviour
{
    public float speed = 10f; // Speed variable to control the forward movement

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the Rigidbody forward at the specified speed
        rb.linearVelocity = transform.forward * speed;
    }
}
