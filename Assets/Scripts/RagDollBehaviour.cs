using UnityEngine;

public class RagDollBehaviour : MonoBehaviour
{
    public Animator animator;
    private Rigidbody[] rigidbodies;
    public bool turnRagdoll = false;
    void Start()
    {
       
        rigidbodies = GetComponentsInChildren<Rigidbody>();
      
        SetRagdollState(turnRagdoll);
    }

   
    public void SetRagdollState(bool state)
    {
        // Disable the animator if enabling the ragdoll, enable it if disabling the ragdoll
        animator.enabled = !state;

        // Enable or disable all rigidbodies and colliders
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = !state;
            //rb.detectCollisions = state;
        }
    }

    public void Update()
    {

        SetRagdollState(turnRagdoll);
   
    }
}
