using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuControl : MonoBehaviour
{
    public GameObject menu;
    public GameControl game_control;
    public InputActionReference open_menu_action;
    public Camera mainCamera; 
    public bool menu_is_active = false;

    private void Awake()
    {
        open_menu_action.action.Enable();
        // subscribe to ToggleMenu function -> when left menu button is clicked, ToggleMenu will be called
        open_menu_action.action.performed += ToggleMenu;
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    private void OnDestroy()
    {
        open_menu_action.action.Disable();
        open_menu_action.action.performed -= ToggleMenu;
        InputSystem.onDeviceChange -= OnDeviceChange;
    }
        
    public void ToggleMenu(InputAction.CallbackContext context)
    {
        if (!menu_is_active)
        {
            menu_is_active = true;
            menu.SetActive(true);
            game_control.stage_ongoing = false;

            // Set the menu's position in front of the camera
            if (mainCamera != null)
            {
                Vector3 positionInFrontOfCamera = mainCamera.transform.position + mainCamera.transform.forward * 1.0f;
                positionInFrontOfCamera += mainCamera.transform.up * -0.2f;
                menu.transform.position = positionInFrontOfCamera;
                menu.transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);
            }
        }
        else
        {
            menu_is_active = false;
            menu.SetActive(false);
            game_control.stage_ongoing = true;
        }
        
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case (InputDeviceChange.Disconnected):
                open_menu_action.action.Disable();
                open_menu_action.action.performed -= ToggleMenu;
                break;
            case (InputDeviceChange.Reconnected):
            {
                    open_menu_action.action.Enable();
                    open_menu_action.action.performed += ToggleMenu;
                    break;
            }
        }
    }
}
