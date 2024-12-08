using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonrotate : MonoBehaviour
{

    // Rotation settings
    public float rotationAmount = 15f;  // How much to rotate (in degrees)
    public float rotationSpeed = 1f;    // Speed of the rotation (in seconds for full motion)

    private Quaternion originalRotation;

    void Start()
    {
        // Save the original rotation
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // Optionally, trigger the animation when a key is pressed (e.g., spacebar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(RotateUpAndDown());
        }
    }

    IEnumerator RotateUpAndDown()
    {
        // Calculate the target rotation (slightly rotated up)
        Quaternion targetRotation = Quaternion.Euler(originalRotation.eulerAngles + new Vector3(rotationAmount, 0, 0));

        // Phase 1: Rotate up to the target rotation
        float timeElapsed = 0f;
        while (timeElapsed < rotationSpeed)
        {
            transform.rotation = Quaternion.Slerp(originalRotation, targetRotation, timeElapsed / rotationSpeed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;

        // Wait for a moment (optional)
        yield return new WaitForSeconds(0.5f);  // Adjust delay as needed

        // Phase 2: Rotate back to the original rotation
        timeElapsed = 0f;
        while (timeElapsed < rotationSpeed)
        {
            transform.rotation = Quaternion.Slerp(targetRotation, originalRotation, timeElapsed / rotationSpeed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = originalRotation;
    }
}
