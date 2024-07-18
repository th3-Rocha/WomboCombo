using UnityEngine;

public class ATKControl : MonoBehaviour
{
    public GameObject ArmInstantie;
    public Transform[] instantiatePoints; // Array to store the 10 instantiation points
    public float instantiateInterval = 1f; // Time interval between instantiations in seconds
    private float timeSinceLastInstantiate;


    void Start()
    {
       
        timeSinceLastInstantiate = 0f;
    }

    void FixedUpdate()
    {
        timeSinceLastInstantiate += Time.deltaTime;

        if (timeSinceLastInstantiate >= instantiateInterval)
        {
            timeSinceLastInstantiate = 0f;

            // Choose a random point from the array of instantiation points
            Transform randomPoint = instantiatePoints[Random.Range(0, instantiatePoints.Length)];
            Instantiate(ArmInstantie, randomPoint.position, randomPoint.rotation, randomPoint);
        }
    }
}
