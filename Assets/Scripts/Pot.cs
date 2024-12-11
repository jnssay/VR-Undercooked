using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour

{
    private bool readyToCook = false;
    public string targetComponentTag = "Stove";

    public bool IsReadyToCook()
    {
        return readyToCook;
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
                Debug.Log("Pot of water is on the target component.");
                readyToCook = true;
            }
        }
    }

    void Update()
    {
        CheckIfOnTargetComponent();
    }
}
