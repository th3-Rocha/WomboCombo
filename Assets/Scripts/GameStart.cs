using UnityEngine;
using TMPro;
using System.Collections;
using static UnityEngine.Rendering.VolumeComponent;

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
    public bool InEnd = false;
    public GameObject PrefabsToStart;
    public LevelAndLayer Level;
    public bool TimerLevelProgession = true;
    void Start()
    {
        StartMenu.SetActive(true);
        HudInGame.SetActive(false);
        EndMenu.SetActive(false);
        PrefabsToStart.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && InStart)
        {
            StartMenu.SetActive(false);
            HudInGame.SetActive(true);
            PrefabsToStart.SetActive(true);
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

        if (InEnd)
        {
            StartMenu.SetActive(false);
            HudInGame.SetActive(false);
            PrefabsToStart.SetActive(false);
            EndMenu.SetActive(true);
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

            yield return null; 
            remainingTime -= Time.deltaTime;
            Debug.Log(seconds);
            if (TimerLevelProgession)
            {
                if (seconds < 24)
                {
                    Level.Stage = 2;

                }
                if (seconds < 21)
                {
                    Level.Stage = 3;

                }
                if (seconds < 18)
                {
                    Level.Stage = 4;

                }
                if (seconds < 15)
                {
                    Level.Stage = 5;

                }
                if (seconds < 12)
                {
                    Level.Stage = 6;
                    TimerLevelProgession = false;
                }
            }
        }

      
        InEnd = true;
        timerText.text = "00:00";
        Debug.Log("GameOver");
    }
}
