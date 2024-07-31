using UnityEngine;

public class CloudFloatingEffect : MonoBehaviour
{
    public float amplitude = 0.5f; // The maximum height the cloud will reach
    public float frequency = 1.0f; // The speed of the floating effect
    private int offSet;
    private Vector3 startPosition;

    void Awake()
    {
        startPosition = transform.position;
        offSet = Random.Range(0, 10);
        float randomX = Random.Range(0f, 360f);
        float randomY = Random.Range(0f, 360f);
        float randomZ = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(randomX, randomY, randomZ);
    }

    void Update()
    {
        // Calculate the new position
        float newY = startPosition.y + Mathf.Sin((Time.time + offSet) * frequency) * amplitude;

        // Apply the new position to the transform
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
