using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText; 
    int GoalScore = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Football")
        {
            GoalScore = GoalScore + 1;
            ScoreText.text = GoalScore.ToString();
        }
    }
}
