using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float health = 100f;
    private RagDollBehaviour ragdoll;
    public GameObject RagDollPivot;
    public Animator animator;
    private Rigidbody[] rigidbodies;
    public bool turnRagdoll = false;
    private CapsuleCollider capsuleCollider;

    void Start()
    {
        rigidbodies = RagDollPivot.GetComponentsInChildren<Rigidbody>();
        SetRagdollState(turnRagdoll);
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            KillEnemy();

        }
    }
    public void SetRagdollState(bool state)
    {
        // Disable the animator if enabling the ragdoll, enable it if disabling the ragdoll
        animator.enabled = !state;
       
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
            KillEnemy();
        }
    }
}
