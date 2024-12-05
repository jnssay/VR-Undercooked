using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

public class CountdownControl : MonoBehaviour
{
    
    public GameObject countdown_panel;
    public TextMeshProUGUI countdown_text;

    private GameControl game_control;
    private float initial_countdown = 3f;
    private float current_countdown;

    // Start is called before the first frame update
    void Start()
    {
        current_countdown = initial_countdown;
        game_control = FindObjectOfType<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game_control.stage_start)
        {
            current_countdown -= Time.deltaTime;
            DisplayInitialCountdown();
        }
    }

    private void DisplayInitialCountdown()
    {
        float countdown_in_integer = Mathf.FloorToInt((current_countdown + 1) % 60);

        if (current_countdown > 0)
        {
            Debug.Log("countdown > 0");
            countdown_panel.SetActive(true);
            countdown_text.text = string.Format("{0}", countdown_in_integer);

        }
        else if (current_countdown <= 0 && current_countdown > -1)
        {
            Debug.Log("countdown == 0");
            countdown_text.text = "Go!";
        }
        else if (current_countdown <= -1)
        {
            game_control.stage_start = false;
            game_control.stage_ongoing = true;
            countdown_panel.SetActive(false);
        }

    }
}
