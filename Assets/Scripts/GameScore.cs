using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public HitHudCounter HitHudCounter;
    public int hitsScore;
    public TextMeshProUGUI score; 

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hitsScore = HitHudCounter.hitCount;
        score.text = hitsScore.ToString(); 
    }
}
