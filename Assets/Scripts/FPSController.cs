using UnityEngine;

public class FPSController : MonoBehaviour
{
    // Public variable to set the maximum FPS
    public int maxFPS = 60;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set the target frame rate to the value of maxFPS
        Application.targetFrameRate = maxFPS;
    }

    // Update is called once per frame
    void Update()
    {
        // Optionally, update the target frame rate dynamically if needed
        if (Application.targetFrameRate != maxFPS)
        {
            Application.targetFrameRate = maxFPS;
        }
    }
}
