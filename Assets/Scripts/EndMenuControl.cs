using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuControl : MonoBehaviour
{
    public GameControl game_control;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (game_control.stage_clear)
        {
            this.gameObject.SetActive(true);
            // Set the menu's position in front of the camera
            if (mainCamera != null)
            {
                Vector3 positionInFrontOfCamera = mainCamera.transform.position + mainCamera.transform.forward * 1.0f;
                positionInFrontOfCamera += mainCamera.transform.up * -0.2f;
                this.gameObject.transform.position = positionInFrontOfCamera;
                this.gameObject.transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);
            }
        }
    }
}
