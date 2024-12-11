using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMenuControl : MonoBehaviour
{
    public GameObject end_menu;

    private GameControl game_control;
    public TextMeshProUGUI scoreText;
    private float gameendscore = 0f;
    private bool scoreSet;

    // Start is called before the first frame update
    void Start()
    {
        game_control = FindObjectOfType<GameControl>();
        scoreSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (game_control.stage_clear)
        {
            end_menu.SetActive(true);
            if (scoreSet)
            {
                scoreText.text = $"Score: {gameendscore}";
            }
            else
            {
                SetGameEndScore(game_control.score);
            }
            
        }
        else
        {
            end_menu.SetActive(false);
        }
    }

    void SetGameEndScore(float endScore)
    {
        gameendscore = endScore;
        scoreSet = true;
    }
}