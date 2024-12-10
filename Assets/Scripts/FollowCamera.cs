using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
       
    }
    void Update()
    {
        // always face camera
        if (mainCamera != null)
        {
            mainCamera = Camera.main;
            transform.LookAt(transform.position + mainCamera.transform.forward);
        }
        
    }
}
