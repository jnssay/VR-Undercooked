using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FryingPan : MonoBehaviour
{
    // Time it takes to cook the food in seconds
    public float cookingTime = 5.0f;
    private bool readyToCook = false;
    public float flipForce = 1.0f;



    // Reference to the cooked version prefab
    public GameObject cookedFoodPrefab;

    public string targetComponentTag = "Stove";

    private void Update()
    {
        CheckIfOnTargetComponent();
        // KillRawFood();
    }

    private void CheckIfOnTargetComponent()
    {
        // Perform a raycast downwards from the frying pan's position
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            // Check if the hit object has the target component tag
            if (hit.collider.CompareTag(targetComponentTag))
            {
                Debug.Log("Frying pan is on the target component.");
                readyToCook = true;
                Debug.Log("Ready to cook");
            }
        }
    }

    private void KillRawFood()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Raw-Fry"))
            {
                RaycastHit whatRawFoodHit;
                if (Physics.Raycast(collider.transform.position, Vector3.up, out whatRawFoodHit))
                {
                    if (whatRawFoodHit.collider.CompareTag("Cooked-Fry"))
                    {
                        Debug.Log("Raw Food still here after cooked food has spawned");
                        Destroy(collider.gameObject);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the pan is tagged as "toFry"
        if (other.CompareTag("Raw-Fry"))
        {
            Debug.Log("Ontrigger");
            // Start the cooking process
            if (readyToCook)
            {
                StartCoroutine(CookFood(other.gameObject));
            }
            // StartCoroutine(CookFood(other.gameObject));
        }
    }

    private IEnumerator CookFood(GameObject rawFood) {
        // Wait for the cooking time to elapse
        Debug.Log("Cooking");
        yield return new WaitForSeconds(cookingTime);
        Vector3 position;
        Quaternion rotation;

        // Replace the raw food with the cooked version
        if (rawFood != null )
        {
            position = rawFood.transform.position;
            rotation = rawFood.transform.rotation;
            // Instantiate the cooked food at the position of the raw food
            GameObject cookedFood = Instantiate(cookedFoodPrefab, position, rotation);
            FlipFood(cookedFood);
        }



        
        // Destroy the raw food
        Destroy(rawFood);
    }

    private void FlipFood(GameObject cookedFood)
    {
        // Ensure the cooked food has a Rigidbody component
        Rigidbody rb = cookedFood.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = cookedFood.AddComponent<Rigidbody>();
        }

        // Apply an upward force to simulate flipping
        rb.AddForce(Vector3.up * flipForce, ForceMode.Impulse);
    }

}
