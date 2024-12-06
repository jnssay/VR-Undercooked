using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuControl : MonoBehaviour
{
    public GameControl game_control;
    public GameObject end_menu;

    // Start is called before the first frame update
    void Start()
    {

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