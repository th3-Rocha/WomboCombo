using UnityEngine;
using TMPro;
using System.Collections;

public class GameStart : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float countdownTime = 24.1f;
    public bool StartTrigger = false;
    public GameObject StartMenu;
    public GameObject HudInGame;
    public GameObject EndMenu;
    public GameObject Player;
    public bool InStart = true;

    void Start()
    {
        StartMenu.SetActive(true);
        HudInGame.SetActive(false);
        EndMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && InStart)
        {
            StartMenu.SetActive(false);
            HudInGame.SetActive(true);
            Player.GetComponent<PlayerComboController>().enabled = true;
            Player.GetComponent<PlayerController>().enabled = true;
            gameObject.GetComponent<AudioSource>().enabled = true;
            InStart = false;
            StartTrigger = true;
        }

        if (StartTrigger)
        {
            StartCoroutine(Countdown());
            StartTrigger = false;
        }
    }

    IEnumerator Countdown()
    {
        float remainingTime = countdownTime;

        while (remainingTime > 0)
        {
            int seconds = Mathf.FloorToInt(remainingTime);
            int milliseconds = Mathf.FloorToInt((remainingTime - seconds) * 100);
            timerText.text = string.Format("{0:00}:{1:00}", seconds, milliseconds);

            yield return null; // Wait for the next frame
            remainingTime -= Time.deltaTime; // Subtract the time that has passed since the last frame
        }

        timerText.text = "00:00";
        Debug.Log("GameOver");
    }
}
