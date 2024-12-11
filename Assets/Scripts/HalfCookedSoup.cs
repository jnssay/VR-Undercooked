using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfCookedSoup : MonoBehaviour
{
    private bool readyToCook = false;
    public string targetComponentTag = "Stove";
    public float cookingTime = 3.0f;
    public GameObject PreFinishSoupPrefab;

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
                Debug.Log("Half Cooked soup is back on the target component.");
                readyToCook = true;
                StartCoroutine(CookSoup());
            }
        }
    }

    private IEnumerator CookSoup()
    {
        if (readyToCook)
        {
            yield return new WaitForSeconds(cookingTime);
            Instantiate(PreFinishSoupPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Not ready to cook, should not reach here");
            yield return null;
        }

    }


    void Update()
    {
        CheckIfOnTargetComponent();
    }
}
