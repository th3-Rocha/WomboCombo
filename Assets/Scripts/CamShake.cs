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
    public bool isShaking = false;

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
            isShaking = true;
        }
        else if (isShaking)
        {
            shakeDuration = 0f;
            transform.localPosition = originalPosition;
            isShaking = false;
        }
    }

    public void TriggerSoftShake()
    {
        if(!isShaking)
        {

            shakeIntensity = softShakeIntensity;
            shakeDuration = softShakeDuration;
            isShaking = true;

        }
    }

    public void TriggerHardShake()
    {
        if (!isShaking)
        {
            shakeIntensity = hardShakeIntensity;
            shakeDuration = hardShakeDuration;
            isShaking = true;
        }
    }
}
