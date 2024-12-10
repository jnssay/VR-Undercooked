using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResumeButton : MonoBehaviour
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
        
    }

    public void ResumeStage()
    {
        game_control.stage_ongoing = true;
        Destroy(gameObject);


    }
}
