using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private bool is_dead = false;
    private Vector3 saved_position;
    private float max_interval = 2f;
    private float current_interval;
    private CharacterController characterController;
    private Camera mainCamera;
    private GameControl game_control;
    private bool already_exist = false;

    void Start()
    {
        mainCamera = Camera.main;
        current_interval = max_interval;
        characterController = GetComponent<CharacterController>();
        game_control = FindObjectOfType<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        current_interval -= Time.deltaTime;
        // save the player's position every x seconds
        if (!characterController.isGrounded)
        {
            current_interval = max_interval;
        }
        if (current_interval <= 0 && characterController.isGrounded && !is_dead)
        {
            Debug.Log("position saved");
            saved_position = this.gameObject.transform.position;
            current_interval = max_interval;
        }
        if (game_control.stage_clear)
        {

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sea")
        {
            is_dead = true;
            respawn();
        }
    }

    private void respawn()
    {
        Debug.Log("respawning");
        this.gameObject.transform.position = saved_position;
        is_dead = false;
    }
}
