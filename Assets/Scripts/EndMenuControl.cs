using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMenuControl : MonoBehaviour
{
    public GameObject end_menu;

    private GameControl game_control;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalRankText;
    public TextMeshProUGUI objectivesCompletedText;
    public TextMeshProUGUI oredersMissedText;

    public float score;
    public int complete;
    public int miss;
    public string rank;
    public box scoreController;

    private bool isDataFetched = false;

    // Start is called before the first frame update
    void Start()
    {
        game_control = FindObjectOfType<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game_control.stage_clear)
        {
            end_menu.SetActive(true);
            if (isDataFetched)
            {
                finalScoreText.text = $"Score: {score}";
                finalRankText.text = $"Rank: {rank}";
                objectivesCompletedText.text = $"Orders Completed: {complete}";
                oredersMissedText.text = $"Orders Missed: {miss}";
            }
            else
            {
                GetData(scoreController);
            }
        }
        else
        {
            end_menu.SetActive(false);
        }
    }

    void GetData(box scoreData)
    {
        score = scoreData.PlayerScore;
        miss = scoreData.missCount;
        complete = scoreData.completeCount;
        
        if(score > 300)
        {
            rank = "A";
        }
        else if (score > 200)
        {
            rank = "B";
        }
        else if (score > 100)
        {
            rank ="C";
        }
        else if (score > 0)
        {
            rank ="D";
        }
        else
        {
            rank = "F";
        }
        isDataFetched = true;
    }
}