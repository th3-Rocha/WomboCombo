using UnityEngine;
using TMPro;

public class HitHudCounter : MonoBehaviour
{
    public GameObject hitHud;
    public GameObject SparkHud;
    private TextMeshProUGUI hitCounterText; // Reference to the TextMesh Pro text component
    public int hitCount = 0; // Variable to keep track of the hit count

    void Start()
    {
        hitCounterText = hitHud.GetComponent<TextMeshProUGUI>();
        UpdateHitCounterText();
    }

    private void FixedUpdate()
    {
        if (hitCount < 1)
        {
            hitHud.SetActive(false);
        }
        else
        {
            hitHud.SetActive(true);
        }
    }

    // Method to update the TextMesh Pro text component and rotate SparkHud
    public void UpdateHitCounterText()
    {
        hitCount++;
        hitCounterText.text = hitCount.ToString();
        RotateSparkHudRandomly();
    }

    // Method to rotate SparkHud randomly
    private void RotateSparkHudRandomly()
    {
        float randomRotation = Random.Range(0f, 360f);
        SparkHud.transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);
    }
}
