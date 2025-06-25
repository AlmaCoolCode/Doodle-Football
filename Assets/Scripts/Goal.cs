using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] private Goal Goal1;
    [SerializeField] private Goal Goal2;
    public int GoalScore = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Football")
        {
            GoalScore = GoalScore + 1;
            ScoreText.text = GoalScore.ToString();
            GameManager.Instance.Reset();
        }
    }

    public void SmallGoals(int whichGoal)
    {
        StartCoroutine(SmallGoals(5, whichGoal));
    }

    IEnumerator SmallGoals(float smallTime, int whichGoal)
    {
        transform.localScale = transform.localScale * 0.5f;
        if (whichGoal == 1)
        {
            transform.localPosition = transform.position + new Vector3(-0.7f, -2, 0);
        }
        else
        {
            transform.localPosition = transform.position + new Vector3(0.7f, -2, 0);
        }
        
        yield return new WaitForSeconds(smallTime);
        transform.localScale = transform.localScale * 2;
        if (whichGoal == 1)
        {
            transform.localPosition = transform.position + new Vector3(0.7f, 2, 0);
        }
        else
        {
            transform.localPosition = transform.position + new Vector3(-0.7f, 2, 0);
        }
            
    }

    
}
