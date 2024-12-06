using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuControl : MonoBehaviour
{
    public GameControl game_control;
    public GameObject start_menu_panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (game_control.stage_start)
        {
            start_menu_panel.SetActive(true);
        }
        else
        {
            start_menu_panel.SetActive(false);
        }
    }
}
