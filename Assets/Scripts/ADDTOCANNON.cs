using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADDTOCANNON : MonoBehaviour
{

    
    public float launchForce = 10.0f;
    public float inclineAngleX = 30f;  // The angle of incline around the X-axis (in degrees)
    public float inclineAngleY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
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

        rb.AddForce(LaunchDirection * launchForce, ForceMode.Impulse);

        StartCoroutine(WaitAMin(cookedFood));

        
    }

    private IEnumerator WaitAMin(GameObject cookedFood)
    {
        yield return new WaitForSeconds(30f);
        Destroy(cookedFood);
    }
}
