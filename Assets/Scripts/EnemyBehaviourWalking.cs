using Unity.Mathematics;
using UnityEngine;

public class EnemyBehaviourWalking : MonoBehaviour
{
    public float health = 100f;
    private RagDollBehaviour ragdoll;
    public GameObject RagDollPivot;
    public Animator animator;
    private Rigidbody[] rigidbodies;
    public bool turnRagdoll = false;
    private CapsuleCollider capsuleCollider;
    public bool IsGrounded = false;
    private float speed;
    private Rigidbody rb;
    public GameObject model;
    public Material[] materials;
    public LayerMask armLayer;
    public LayerMask CarLayer;
    // Maximum speed the enemy can move
    public float maxSpeed = 5.0f;

    void Start()
    {
        rigidbodies = RagDollPivot.GetComponentsInChildren<Rigidbody>();
        SetRagdollState(turnRagdoll);
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();

        // Set random material from materials array
        SkinnedMeshRenderer skinnedMeshRenderer = model.GetComponent<SkinnedMeshRenderer>();
        int randomMaterialIndex = UnityEngine.Random.Range(0, materials.Length);
        skinnedMeshRenderer.material = materials[randomMaterialIndex];

        int randomValue = UnityEngine.Random.Range(1, 6);

        if (randomValue == 1 || randomValue == 3)
        {
            animator.Play("walk1");
            speed = 1.0f;
        }
        else if (randomValue == 2 )
        {
            animator.Play("walk2");
            speed = 0.3f;
        }
        else
        {
            animator.Play("walk3");
            speed = 1.0f;
        }

    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            KillEnemy();
        }

        if (!turnRagdoll)
        {
            
            MoveForward();
            LimitVelocity();
        }
        else
        {
            SetRagdollState(turnRagdoll);
        }
    }

    void MoveForward()
    {
        Vector3 forwardMovement = transform.forward * speed;
        rb.AddForce(forwardMovement, ForceMode.Acceleration);
    }

    void LimitVelocity()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    public void SetRagdollState(bool state)
    {
        // Disable the animator if enabling the ragdoll, enable it if disabling the ragdoll
        animator.enabled = !state;
        
        if (state)
        {
            rb.freezeRotation = false;
        }
        // Enable or disable all rigidbodies and colliders
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = !state;
            rb.detectCollisions = state;
        }
    }

    public void KillEnemy()
    {
        capsuleCollider.enabled = false;
        SetRagdollState(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
     

        if (((1 << collision.gameObject.layer) & armLayer) != 0)
        {
            health = 0;
        }

        if (((1 << collision.gameObject.layer) & CarLayer) != 0)
        {
            health = 0;
            rb.AddForce(Vector3.up *200, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dir"))
        {
            Quaternion otherRotation = other.gameObject.transform.rotation;

            rb.transform.localRotation = otherRotation;

        }
    }
}
