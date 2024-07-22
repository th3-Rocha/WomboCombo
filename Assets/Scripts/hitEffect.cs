using UnityEngine;

public class hitEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource atkHit;

    void Start()
    {
        atkHit = GetComponent<AudioSource>();

        atkHit.pitch = Random.Range(1.25f, 2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
