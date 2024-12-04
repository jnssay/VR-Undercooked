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
    public GameObject end_menu;
    public Camera mainCamera;
    public TextMeshProUGUI timer_text;
    public float max_time = 240f; // 4 mins game time
    public float current_time;
    public float score = 0f;

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



    public void DisplayTime()
    {
        if (stage_start)
        {
            seconds = Mathf.FloorToInt(current_time % 60);
        }
        else
        {
            seconds = Mathf.FloorToInt((current_time + 1) % 60);
        }
        if (current_time > 0)
        {
            minutes = Mathf.FloorToInt((current_time + 1) / 60);
            
        }
        else
        {
            minutes = 0f;
        }



        timer_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StageCleared()
    {
        stage_ongoing = false;
        stage_clear = true;
        // show end menu
        end_menu.SetActive(true);
        // Set the menu's position in front of the camera
        if (mainCamera != null)
        {
            Vector3 positionInFrontOfCamera = mainCamera.transform.position + mainCamera.transform.forward * 1.0f;
            positionInFrontOfCamera += mainCamera.transform.up * -0.2f;
            end_menu.transform.position = positionInFrontOfCamera;
            end_menu.transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);
        }
    }

    private void StageStart()
    {
        stage_start = true;
    }
}