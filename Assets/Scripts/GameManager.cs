using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Football football;
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;
    [SerializeField] GameObject goalBanner;
    [SerializeField] int timer = 90;
    [SerializeField] TMP_Text Timer;
    private int TimerStart;
    // Start is called before the first frame update
    void Start()
    {
        TimerStart = timer;
        Instance = this;
        StartCoroutine(Countdown());
        UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateTimerText()
    {
        int minutes = timer / 60;
        int seconds = timer % 60;
        string extra = "";
        if (seconds < 10)
        {
            extra = "0";
        }
        Timer.text = minutes + ":" + extra + seconds;
    }

    public void Reset()
    {
        football.Reset();
        player1.Reset();
        player2.Reset();
        StartCoroutine(ShowBanner());
    }

    private IEnumerator ShowBanner()
    {
        goalBanner.SetActive(true);
        yield return new WaitForSeconds(1);
        goalBanner.SetActive(false);
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        timer = timer - 1;
        UpdateTimerText();
        if (timer > 0)
        {
            StartCoroutine(Countdown());
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        print("Game over");
    }

    void FullReset()
    {
        Reset();
    }
}
