using UnityEngine;

public class ATKControl : MonoBehaviour
{
    public GameObject ArmInstantie;
    public Transform[] instantiatePoints;
    public float instantiateInterval = 1f;
    private float timeSinceLastInstantiate;
    public LayerMask enemyLayer; // Layer mask to specify enemy layer
    public bool isCooldown; // Cooldown flag
    private float lastHitTime;
    public float cooldownDuration = 1f; // Cooldown duration in seconds
    public AudioSource atkHit;
    public AudioSource atkMiss;
    void Start()
    {
        atkHit = GetComponent<AudioSource>();
        timeSinceLastInstantiate = 0f;
        isCooldown = false;
        lastHitTime = -cooldownDuration; // Initialize to allow immediate first hit
    }

    void FixedUpdate()
    {
        timeSinceLastInstantiate += Time.deltaTime;
        if (cooldownDuration <= Time.time - lastHitTime)
        {
            isCooldown = false;
        }
        if (timeSinceLastInstantiate >= instantiateInterval && Time.time >= lastHitTime )
        {
            timeSinceLastInstantiate = 0f;
            Transform randomPoint = instantiatePoints[Random.Range(0, instantiatePoints.Length)];
            GameObject instantiatedObject = Instantiate(ArmInstantie, randomPoint.position, randomPoint.rotation);
            instantiatedObject.AddComponent<CollisionDetector>().Init(this, enemyLayer);
        }

        if(!isCooldown)
        {
            atkHit.pitch = Random.Range(1.25f, 2f);
            atkHit.mute = true;
            atkMiss.mute = false;

        }
        else
        {
            atkHit.mute = false;
            atkMiss.mute = true;
        }
    }

    public void OnHitEnemy()
    {
        if (!isCooldown)
        {
            Debug.Log("Hit enemy!");
            lastHitTime = Time.time;
            isCooldown = true;
        }
        else
        {
            Debug.Log("Hit enemy but in cooldown");

        }
    }
}
