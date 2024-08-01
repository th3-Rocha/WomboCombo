using UnityEngine;

public class NukeInstant : MonoBehaviour
{
    public GameObject Explosion; // Drag your prefab here in the Unity Editor
    public CamShake camShake;

    void Start()
    {
      
    }

    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Explosion != null)
        {
            // Instantiate the explosion prefab at the current position with no rotation
            Instantiate(Explosion, transform.position, Quaternion.identity);
            camShake.TriggerHardShake();
            // Destroy the current GameObject
            Destroy(gameObject);
        }
    }
}
