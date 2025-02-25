using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Football football;
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;
    [SerializeField] GameObject goalBanner;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
