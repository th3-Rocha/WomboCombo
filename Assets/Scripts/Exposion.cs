using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float growthRate = 0.1f; // How much the GameObject grows each fixed frame

    void FixedUpdate()
    {
        // Increase the size of the GameObject
        transform.localScale += Vector3.one * growthRate * Time.fixedDeltaTime;
    }
}
