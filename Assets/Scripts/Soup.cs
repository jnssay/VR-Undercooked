using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soup : MonoBehaviour
{
    private Pot pot;
    private Vector3 position;
    private Quaternion rotation;
    public GameObject PreCookSoupPrefab;
    public GameObject PreFinishSoupPrefab;
    public float cookingTime = 3.0f;
    private bool readyToCook = false;

    void Awake()
    {
        pot = GetComponentInParent<Pot>();
        position = pot.transform.position;
        rotation = pot.transform.rotation;
    }

    void Update()
    {
        readyToCook = pot.IsReadyToCook();

    }

    private void OnTriggerEnter(Collider ingredient)
    {
        if (ingredient.CompareTag("Raw-Fry"))
        {
            Debug.Log("Meat is in the water");
            Destroy(ingredient.gameObject);
            PutMeatinSoup(position, rotation);

        }
    }

    private void PutMeatinSoup(Vector3 position, Quaternion rotation)
    {
        GameObject PreCookSoup = Instantiate(PreCookSoupPrefab, position, rotation);
        Debug.Log("Added meat to soup");
        if (readyToCook)
        {
            MakePotInvisibleAndNonInteractable();
            StartCoroutine(CookSoup(position, rotation, PreCookSoup));
        }
    }

    private void MakePotInvisibleAndNonInteractable()
    {
        // Disable the renderer to make the pot invisible
        Renderer potRenderer = pot.GetComponent<Renderer>();
        if (potRenderer != null)
        {
            potRenderer.enabled = false;
        }

        // Disable the collider to make the pot non-interactable
        Collider potCollider = pot.GetComponent<Collider>();
        if (potCollider != null)
        {
            potCollider.enabled = false;
        }

        // Optionally, disable any other components that make the pot interactable
    }

    private IEnumerator CookSoup(Vector3 position, Quaternion rotation, GameObject PreCookSoup)
    {
        Debug.Log("Cooking");
        yield return new WaitForSeconds(cookingTime);

        float elapsedTime = 0f;

        while (elapsedTime < cookingTime)
        {
            if (!readyToCook)
            {
                Debug.Log("Cooking stopped because readyToCook is false.");
                yield break; // Exit the coroutine
            }

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Audio should be triggered here

        // Fire should be triggered here

        // Soup is done
        Instantiate(PreFinishSoupPrefab, position, rotation);
        Destroy(pot.gameObject);
        Destroy(PreCookSoup);

    }
}
