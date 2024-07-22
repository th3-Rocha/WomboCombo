using UnityEngine;
using System.Collections;

public class PedSpawner : MonoBehaviour
{
    public GameObject pedPrefab; // Prefab to be instantiated
    public float minDelay = 1f; // Minimum delay in seconds
    public float maxDelay = 5f; // Maximum delay in seconds

    private GameObject currentPed; // Reference to the currently spawned prefab

    void Start()
    {
        StartCoroutine(SpawnPedAfterDelay());
    }

    IEnumerator SpawnPedAfterDelay()
    {
        while (true)
        {
            float delay = UnityEngine.Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            if (currentPed == null)
            {
                currentPed = Instantiate(pedPrefab, transform.position, transform.rotation);
                currentPed.GetComponent<PedBehaviour>().OnDestroyed += HandlePedDestroyed;
            }
        }
    }

    public void HandlePedDestroyed()
    {
        if (this != null) 
        {
            if (currentPed != null)
            {
                currentPed.GetComponent<PedBehaviour>().OnDestroyed -= HandlePedDestroyed;
                currentPed = null;
            }
            StartCoroutine(SpawnPedAfterDelay());
        }
    }
}
