using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuControl : MonoBehaviour
{
    public GameObject end_menu;

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
            end_menu.SetActive(true);

        }
        else
        {
            end_menu.SetActive(false);
        }
    }
}