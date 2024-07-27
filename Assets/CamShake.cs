using UnityEngine;

public class CamShake : MonoBehaviour
{
    public float softShakeIntensity = 0.1f;
    public float softShakeDuration = 0.5f;
    public float hardShakeIntensity = 0.3f;
    public float hardShakeDuration = 1f;

    private Vector3 originalPosition;
    private float shakeDuration = 0f;
    private float shakeIntensity = 0f;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeIntensity;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = originalPosition;
        }
    }

    public void TriggerSoftShake()
    {
        shakeIntensity = softShakeIntensity;
        shakeDuration = softShakeDuration;
    }

    public void TriggerHardShake()
    {
        shakeIntensity = hardShakeIntensity;
        shakeDuration = hardShakeDuration;
    }
}
