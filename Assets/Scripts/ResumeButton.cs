using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResumeButton : MonoBehaviour
{
    public MenuControl menu_control;
    public GameControl game_control;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeStage()
    {
        game_control.stage_ongoing = true;
        menu_control.menu_is_active = false;
        menu_control.menu.SetActive(false);

    }
}
