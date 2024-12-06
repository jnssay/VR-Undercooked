using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public bool stage_clear = false;
    public bool stage_ongoing = false;
    public bool stage_start = true;
    //public GameObject end_menu;
    public Camera mainCamera;
    public TextMeshProUGUI timer_text;
    //public TextMeshProUGUI countdown_text;
    //public GameObject countdown_panel;
    public float max_time = 240f; // 4 mins game time
    public float current_time;
    public float score = 0f;

    private float initial_countdown = 3f;
    private float current_countdown;
    private float minutes;
    private float seconds;



    // Awake() is called when this script is loaded and is only called once per lifetime of this script
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        current_time = max_time;
        current_countdown = initial_countdown;
    }

    // Update is called once per frame
    void Update()
    {
        QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
        Application.targetFrameRate = 60;   // Set framerate to 60 FPS

        DisplayTime();
        if (stage_start)
        {
            Debug.Log("stage start");
            current_countdown -= Time.deltaTime;
            //DisplayInitialCountdown();
        }
        if (stage_ongoing)
        {
            Debug.Log("stage ongoing");
            current_time -= Time.deltaTime;    // start countdown

        }
        if (current_time <= 0)
        {
            // if countdown reaches 0, stage ends
            StageCleared();
        }
    }

    //private void DisplayInitialCountdown()
    //{
    //    float countdown_in_integer = Mathf.FloorToInt((current_countdown + 1) % 60);

    //    if (current_countdown > 0)
    //    {
    //        Debug.Log("countdown > 0");
    //        countdown_panel.SetActive(true);
    //        countdown_text.text = string.Format("{0}", countdown_in_integer);

    //    }
    //    else if (current_countdown <= 0 && current_countdown > -1)
    //    {
    //        Debug.Log("countdown == 0");
    //        countdown_text.text = "Go!";
    //    }
    //    else if (current_countdown <= -1)
    //    {
    //        stage_start = false;
    //        stage_ongoing = true;
    //        countdown_panel.SetActive(false);
    //    }

    //}

    public void DisplayTime()
    {
        float displayTime;

        if (stage_start && !stage_ongoing) // Before countdown starts
        {
            displayTime = Mathf.Ceil(current_time); // Always show the ceiling value
        }
        else if (stage_ongoing) // During countdown
        {
            displayTime = current_time > 0 ? Mathf.Ceil(current_time) : 0; // Use ceiling during countdown
        }
        else // Edge case or default
        {
            displayTime = current_time > 0 ? Mathf.Ceil(current_time) : 0;
        }

        seconds = Mathf.FloorToInt(displayTime % 60);
        minutes = Mathf.FloorToInt(displayTime / 60);

        timer_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void StageCleared()
    {
        stage_ongoing = false;
        stage_clear = true;
        //// show end menu
        //end_menu.SetActive(true);
        //// Set the menu's position in front of the camera
        //if (mainCamera != null)
        //{
        //    Vector3 positionInFrontOfCamera = mainCamera.transform.position + mainCamera.transform.forward * 1.0f;
        //    positionInFrontOfCamera += mainCamera.transform.up * -0.2f;
        //    end_menu.transform.position = positionInFrontOfCamera;
        //    end_menu.transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);
        //}
    }

    private void StageStart()
    {
        stage_start = true;
    }
}
