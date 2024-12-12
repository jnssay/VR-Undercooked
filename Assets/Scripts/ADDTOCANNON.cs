using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADDTOCANNON : MonoBehaviour
{
    public AudioClip cannon_sound;
    public float launchForce = -50.0f;
    public float inclineAngleX = 30f;  // The angle of incline around the X-axis (in degrees)
    public float inclineAngleY = 0f;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LaunchFood(GameObject cookedFood)
    {
        // Ensure the cooked food has a Rigidbody component
        Rigidbody rb = cookedFood.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = cookedFood.AddComponent<Rigidbody>();
        }
        Quaternion rotation = Quaternion.Euler(inclineAngleX, inclineAngleY, 0);
        Vector3 LaunchDirection = rotation * Vector3.forward;
        if (source != null)
        {
            source.PlayOneShot(cannon_sound);
        }

        rb.AddForce(LaunchDirection * launchForce, ForceMode.Impulse);
    }
}
