using UnityEngine;

public class SelfDestruction : MonoBehaviour
{
    // Public variable to set the delay before destruction in seconds
    public float destroyDelay = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Schedule the destruction of the GameObject after destroyDelay seconds
        Destroy(gameObject, destroyDelay);
    }
}
