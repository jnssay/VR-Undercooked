using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuControl : MonoBehaviour
{
    private GameControl game_control;
    // Start is called before the first frame update
    void Start()
    {
        game_control = FindObjectOfType<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game_control.stage_start)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
