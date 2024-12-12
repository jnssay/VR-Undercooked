using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerControl : MonoBehaviour
{
    public GameObject timer_panel;
    public GameObject timer_bar;

    private GameControl game_control;

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
            timer_panel.SetActive(false);
            timer_bar.SetActive(false);
        }
        else
        {
            timer_panel.SetActive(true);
            timer_bar.SetActive(true);
        }
    }
}
