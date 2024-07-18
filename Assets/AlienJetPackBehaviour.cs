using UnityEngine;

public class AlienJetPackBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private Transform playerTransform;

    // Speed factor to control the movement speed towards the player
    public float speed = 1.0f;
    public float rotationSpeed = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player GameObject with tag 'Player' not found.");
        }
    }

    void FixedUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

            rb.AddForce(directionToPlayer * speed);

            Quaternion targetRotation = Quaternion.LookRotation(-directionToPlayer);

     
            Quaternion smoothedRotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rb.MoveRotation(smoothedRotation);
        }
    }
}
