using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform cam;

    void LateUpdate()
    {
        // always face camera
        transform.LookAt(transform.position + cam.forward);
    }
}
