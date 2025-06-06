using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public Football football;
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;
    [SerializeField] GameObject goalBanner;
    [SerializeField] private Goal goal1;
    [SerializeField] private Goal goal2;
    [SerializeField] int timer = 90;
    [SerializeField] TMP_Text Timer;
    [SerializeField] AudioSource whistle;
    [SerializeField] GameObject rot;
    [SerializeField] GameObject ichSeheRot;
    [SerializeField] GameObject ichSehe;
    [SerializeField] GameObject schwarz;
    [SerializeField] GameObject schwarz2;
    [SerializeField] GameObject schwarz3;
    [SerializeField] GameObject schwarz4;
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
        whistle.Play();
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

    public void IchSeheRot()
    {
        StartCoroutine(Rot());
    }

    public void IchBin1ProzentSchwarz()
    {
        StartCoroutine(Schwarz(7));
    }
    private IEnumerator Schwarz(float time)
    {
        schwarz.SetActive(true);
        schwarz2.SetActive(false);
        schwarz3.SetActive(true);
        schwarz4.SetActive(true);
        goal1.schwarz(1);
        goal2.schwarz(1);
        football.schwarz(1);
        yield return new WaitForSeconds(time);
        schwarz2.SetActive(true);
        schwarz.SetActive(false);
        schwarz3.SetActive(false);
        schwarz4.SetActive(false);
        goal1.schwarz(2);
        goal2.schwarz(2);
        football.schwarz(1);
    }

    private IEnumerator Rot()
    {
        rot.SetActive(true);
        ichSeheRot.SetActive(true);
        ichSehe.SetActive(true);
        yield return new WaitForSeconds(7);
        ichSeheRot.SetActive(false);
        rot.SetActive(false);
        ichSehe.SetActive(false);
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
        if (goal1.GoalScore > goal2.GoalScore)
        {
            SceneManager.LoadScene("Red win");
        }
        else if (goal2.GoalScore > goal1.GoalScore)
        {
            SceneManager.LoadScene("Green win");
        }
        else
        {
            SceneManager.LoadScene("Draw");
        }
        print("Game over");
    }

    void FullReset()
    {
        Reset();
    }
}
