using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
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

    public void StartStage()
    {
        Debug.Log("stage started!");
        game_control.stage_start = false;
        game_control.stage_ongoing = true;
        Destroy(gameObject);
    }
}
